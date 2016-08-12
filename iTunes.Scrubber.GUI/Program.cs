using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using iTunes.Scrubber.DataSources;

namespace iTunes.Scrubber.GUI
{
    class Program
    {
        public static Factories.ScrubberFactory ScrubberFactory { get; set; }

        public static Enums.FormEnum CurrentForm { get; set; }

        public static Delegates.Filter<Interfaces.IMediaItem> Filter { get; set; }

        static void Main(string[] args)
        {
            #region Collect Params

            if (args.Length == 0)
            {
                Console.Write("Please enter args: ");
                args = Console.ReadLine().Split(' ');
            }

            for (Int32 i = 0, numArgs = args.Length; i < numArgs; i++)
                args[i] = args[i].ToLowerInvariant();

            #endregion

            #region Build Filter

            Delegates.Filter<Interfaces.IMediaItem> filters = null;

            foreach (String filterType in new String[] { "meta_tv", "meta_movie", "meta_movies", "done_movies", "done_movie", "timespan", "modified", "added", "series", "forceart", "nochanges" })
            {
                Delegate newFilter = null;

                if (args.Contains<String>(filterType))
                    switch (filterType)
                    {
                        case "meta_tv":
                            newFilter = Filters<Interfaces.IMediaItem>.CompleteMetaFilter_TV(false);
                            break;
                        case "meta_movies":
                        case "meta_movie":
                            newFilter = Filters<Interfaces.IMediaItem>.CompleteMetaFilter_Movie(false);
                            break;
                        case "meta+movie":
                        case "meta+movies":
                            newFilter = Filters<Interfaces.IMediaItem>.CompleteMetaFilter_Movie(true);
                            break;
                        case "done_movies":
                        case "done_movie":
                            newFilter = Filters<Interfaces.IMediaItem>.CompleteMetaFilter_Movie(true);
                            break;
                        case "modified":
                            Console.Write("Enter Date Modified: ");
                            newFilter = Filters<Interfaces.IMediaItem>.DateModfiedFilter(DateTime.Parse(Console.ReadLine()));
                            break;
                        case "added":
                            Console.Write("Enter Date Added: ");
                            newFilter = Filters<Interfaces.IMediaItem>.DateAddedFilter(DateTime.Parse(Console.ReadLine()));
                            break;
                        case "timespan":
                            Console.Write("Enter Timespan: ");
                            newFilter = Filters<Interfaces.IMediaItem>.TimeSpanFilter(TimeSpan.Parse(Console.ReadLine()));
                            break;
                        case "series":
                            Console.Write("Enter Series List: ");
                            newFilter = Filters<Interfaces.IMediaItem>.SeriesFilter(Console.ReadLine().Split(',', '|'));
                            break;
                        case "forceart":
                            Constants.CHANGEART = true;
                            break;
                        case "nochanges":
                            Constants.NOCHANGES = true;
                            break;
                    }

                if (newFilter != null)
                {
                    if (filters == null)
                        filters = (Interfaces.IMediaItem mediaItem) => (Boolean)newFilter.DynamicInvoke(mediaItem);
                    else
                    {
                        Delegate oldFilter = filters;
                        filters = (Interfaces.IMediaItem mediaItem) => (Boolean)newFilter.DynamicInvoke(mediaItem) && (Boolean)oldFilter.DynamicInvoke(mediaItem);
                    }
                }

                if (filters == null)
                    filters = (Interfaces.IMediaItem mediaItem) => true;

                Filter = filters;
            }

            #endregion

            using (ScrubberFactory = new Factories.ScrubberFactory())
            {
                #region Splash Screen

                Boolean done = false;

                if (args.Contains<String>("gui") || false)
                {
                    ThreadPool.QueueUserWorkItem((x) =>
                    {
                        using (frmSplash splash = new frmSplash())
                        {
                            splash.Show();

                            while (!done)
                                Application.DoEvents();

                            splash.Close();
                        }
                    });
                }

                #endregion

                #region Initialize Data Stores

                if (true)
                {
                    Console.WriteLine("== Initializing iTunes DataSource ==");

                    DataSources.ITunesSource.Instance.Initialize();

                    CurrentForm = Enums.FormEnum.Main;

                    done = true;
                }

                #endregion

                #region Login To Sites

                if (args.Contains<String>("warez"))
                    DataSources.Warez_BBSource.Instance.Login("alluran", "dragon");

                #endregion

                #region GUI

                if (args.Contains<String>("gui") || false)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (args.Contains<String>("movie"))
                        CurrentForm = Enums.FormEnum.Movie;
                    if (args.Contains<String>("tvshow"))
                        CurrentForm = Enums.FormEnum.TVShow;
                    if (args.Contains<String>("music"))
                        CurrentForm = Enums.FormEnum.Music;
                    if (args.Contains<String>("musicvideo"))
                        CurrentForm = Enums.FormEnum.MusicVideo;

                    while (CurrentForm != Enums.FormEnum.None)
                        switch(CurrentForm)
                        {
                            case Enums.FormEnum.Main:
                                Application.Run(new frmMain());
                                break;
                            case Enums.FormEnum.Movie:
                                Application.Run(new frmMovie());
                                break;
                            default:
                                CurrentForm = Enums.FormEnum.Main;
                                break;
                        }
                }

                #endregion

                #region Scrub TV Shows

                if (args.Contains<String>("scrubtv") || false)
                {
                    Console.WriteLine("== Scrub TV Shows ==");

                    ScrubberFactory.TVShowScrubber.Clean(
                        filter: (movie) => Program.Filter(movie),
                        sorter: Sorters<MediaItems.TVShowItem>.ShowSorter
                    );
                }

                #endregion

                #region Remove Duplicate TV Shows

                if (args.Contains<String>("duplicates") || false)
                {
                    Console.WriteLine("== Remove Duplicate TV Shows==");

                    ScrubberFactory.TVShowScrubber.RemoveDuplicates(
                        filter: Filters<MediaItems.TVShowItem>.CompleteMetaFilter_TV(true),
                        sorter: Sorters<MediaItems.TVShowItem>.ShowSorter
                    );
                }

                #endregion

                #region List Missing Episodes

                if (args.Contains<String>("missing") || false)
                {
                    Console.WriteLine("== List Missing Episodes ==");

                    ScrubberFactory.TVShowScrubber.GetMissing(
                        sorter: Sorters<MediaItems.TVShowItem>.ShowSorter
                    ).ToList().ForEach(x => Console.WriteLine("{0} [{1:D2}x{2:D2}] {3}", x.Show, x.Season, x.Episode, x.Title));
                }

                #endregion

                #region List All Episodes In A Series

                if (args.Contains<String>("list") || false)
                {
                    Console.WriteLine("== List All Episodes In A Series ==");

                    Console.Write("Enter Series To List: ");

                    String seriesSearch = Console.ReadLine();

                    Console.Write("Enter Season To List: ");

                    String seasonSearch = Console.ReadLine();

                    DataSources.IMDBSource.Instance.GetEpisodes(
                        series: seriesSearch,
                        season: Int32.Parse(seasonSearch),
                        sorter: Sorters<MediaItems.TVShowItem>.ShowSorter
                    ).ToList().ForEach(x => Console.WriteLine("{0} [{1:D2}x{2:D2}] {3}", x.Show, x.Season, x.Episode, x.Title));
                }

                #endregion

                #region Scrub Movies

                if (args.Contains<String>("scrubmovie") || false)
                {
                    Console.WriteLine("== Scrub Movies ==");

                    ScrubberFactory.MovieScrubber.Clean();
                }

                #endregion

                #region Scrub Music Videos

                if (args.Contains<String>("scrubmusicvideo") || false)
                {
                    Console.WriteLine("== Scrub Music Videos ==");

                    ScrubberFactory.MusicVideoScrubber.Clean();
                }

                #endregion

                #region Scrub Music

                if (args.Contains<String>("scrubmusic") || false)
                {
                    Console.WriteLine("== Scrub Music ==");

                    ScrubberFactory.MusicScrubber.Clean();
                }

                #endregion

                #region Scrape Links

                if (args.Contains<String>("scrape") || false)
                {
                    Console.WriteLine("== List Links For Missing Episodes ==");

                    (from episode in 
                          ScrubberFactory.TVShowScrubber.GetMissing(
                          sorter: Sorters<MediaItems.TVShowItem>.ShowSorter)
                     // ,filter: Filters<MediaItems.TVShowItem>.SeriesFilter("United States Of Tara", "House", "West Wing", "Futurama", "American Dad!", "Glee", "Peep Show", "Mad Men", "Babylon 5", "Big Bang Theory", "Family Guy", "NCIS", "Heroes", "Boston Legal", "How I Met Your Mother", "Castle", "Archer", "Robot Chicken", "Stargate SG-1", "Flight Of The Conchords", "Doctor Who (2005)", "MythBusters", "Burn Notice", "The Simpsons", "Bones", "South Park", "Torchwood", "Supernatural", "Life Unexpected", "Skins", "Stargate Atlantis", "Hellcats", "The Wire", "Top Gear", "Underbelly", "Stargate Universe", "The Cleveland Show", "Grey's Anatomy", "Tru Calling"))
                     // DataSources.IMDBSource.Instance.GetEpisodes("Scrubs").Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("Tru Calling")).Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("Six Feet Under")).Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("Torchwood")).Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("Castle")).Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("Bones")).Union(
                     // DataSources.IMDBSource.Instance.GetEpisodes("House"))
                     from topic in DataSources.Warez_BBSource.Instance.Search(String.Format("{0} Season {1}", episode.Show, episode.Season), Enums.ForumEnum.TVShows).GetTopics(episode)
                     where topic != null
                     from links in topic.GetLinks(episode)
                     where links != null
                     from link in links
                     select link
                    ).Distinct().ToList().ForEach(link => Console.WriteLine(link));
                }

                #endregion

                #region Scrape Selected Links

                if (args.Contains<String>("selected") || false)
                {
                    Console.WriteLine("== List Links For Selected Missing Episodes ==");
                    Console.Write("Enter comma seperated list of series to search for: ");
                    String seriesList = Console.ReadLine().ToLowerInvariant();

                    (from series in seriesList.Split(',')
                     from episode in DataSources.IMDBSource.Instance.GetEpisodes(series)
                     from topic in DataSources.Warez_BBSource.Instance.Search(String.Format("{0} Season {1]", episode.Show, episode.Season), Enums.ForumEnum.TVShows).GetTopics(episode)
                     where topic != null
                     from links in topic.GetLinks(episode)
                     where links != null
                     from link in links
                     select link
                    ).Distinct().ToList().ForEach(link => Console.WriteLine(link));
                }

                #endregion

                Console.WriteLine("== Complete ==");
            }
        }
    }

}
