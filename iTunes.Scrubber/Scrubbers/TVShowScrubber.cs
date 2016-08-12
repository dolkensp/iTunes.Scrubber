using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace iTunes.Scrubber.Scrubbers
{
    public class TVShowScrubber : BaseClasses.ScrubberBase<Parsers.TVShowParser, MediaItems.TVShowItem>
    {
        internal TVShowScrubber() { }

        public IEnumerable<MediaItems.TVShowItem> GetAll(Delegates.Filter<MediaItems.TVShowItem> filter = null, Delegates.Sorter<MediaItems.TVShowItem> sorter = null)
        {
            IEnumerable<MediaItems.TVShowItem> mediaItems = (from series in DataSources.ITunesSource.Instance.AllSeries
                                                             from season in DataSources.ITunesSource.Instance.AllSeasons(series)
                                                             from imdbTV in DataSources.IMDBSource.Instance.GetEpisodes(series, season, filter, sorter)
                                                             where imdbTV != null
                                                             select imdbTV);

            return mediaItems;
        }

        public IEnumerable<MediaItems.TVShowItem> GetMissing(Delegates.Filter<MediaItems.TVShowItem> filter = null, Delegates.Sorter<MediaItems.TVShowItem> sorter = null)
        {
            List<Tuple<String, Int32?, Int32?>> tvShows = (from tvShow in DataSources.ITunesSource.Instance.GetMedia<MediaItems.TVShowItem>(filter, sorter)
                                                           select new Tuple<String, Int32?, Int32?>(tvShow.Show, tvShow.Season, tvShow.Episode)).ToList<Tuple<String, Int32?, Int32?>>();

            IEnumerable<MediaItems.TVShowItem> mediaItems = (from imdbTV in this.GetAll(filter, sorter)
                                                             let tupleTV = new Tuple<String, Int32?, Int32?>(imdbTV.Show, imdbTV.Season, imdbTV.Episode)
                                                             where !tvShows.Contains<Tuple<String, Int32?, Int32?>>(tupleTV)
                                                             select imdbTV);

            return mediaItems;
        }

        public void RemoveDuplicates(Delegates.Filter<MediaItems.TVShowItem> filter = null, Delegates.Sorter<MediaItems.TVShowItem> sorter = null)
        {
            foreach (MediaItems.TVShowItem episode in (from episode in DataSources.ITunesSource.Instance.GetMedia<MediaItems.TVShowItem>(filter, sorter)
                                                       let comparison = new Tuple<String, Int32?, Int32?>(episode.Show, episode.Season, episode.Episode)
                                                       orderby episode.LocalTrack.Size descending
                                                       group episode by comparison into episodeGroup
                                                       where episodeGroup.Count() > 1
                                                       from item in episodeGroup.Skip(1)
                                                       select item))
            {
                Console.WriteLine("Removing: {0}\r\n\t{1} {2:D2}x{3:D2} - {4}", episode.Location, episode.Show, episode.Season, episode.Episode, episode.Title);

                String destination = Path.ChangeExtension(episode.Location, "bak");
                
                Int32 i = 0;

                while (File.Exists(destination))
                    destination = Path.ChangeExtension(episode.Location, String.Format("ba{0}", i++));

                if (File.Exists(episode.Location))
                    File.Move(episode.Location, destination);

                if (!String.IsNullOrWhiteSpace(episode.Location))
                    episode.LocalTrack.Delete();
            }
        }
    }
}
