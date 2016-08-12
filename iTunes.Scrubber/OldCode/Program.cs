using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace iTunes.Scrubber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MetaScrub filler = new MetaScrub())
            {
                Console.WriteLine("== Find Series ==");

                if (false)
                    foreach (String link in (from linkGroup
                                                 in filler.FindSeriesLinks("Bones", null, null)
                                             from singleLink
                                                 in linkGroup.FirstOrDefault() ?? Enumerable.Empty<String>()
                                             select singleLink))
                        Console.WriteLine("{0}", link);
                else
                    Console.WriteLine("Skipped");

                Console.WriteLine();
                Console.WriteLine("== Process All Metadata ==");

                // Updates Metadata for all TV Shows
                if (true)
                    filler.ProcessTVShows(
                        filter: (TVShow show) => (DateTime.Now - (show.DateModified ?? show.DateAdded ?? DateTime.Now)).TotalDays < 14,
                        sortBy: (TVShow show) => DateTime.Now - (show.DateModified ?? show.DateAdded ?? DateTime.Now)
                    );
                else
                    Console.WriteLine("Skipped");

                Console.WriteLine();
                Console.WriteLine("== List All Episodes ==");

                // Lists all current episodes
                if (false)
                    foreach (TVShow show in filler.GetTVShows())
                        Console.WriteLine("[{1:D2}x{2:D2}] {0}: {3}", show.Series, show.Season ?? 0, show.Episode ?? 0, show.Title);
                else
                    Console.WriteLine("Skipped");

                Console.WriteLine();
                Console.WriteLine("== List Missing Episodes ==");

                // Lists all missing episodes
                if (false)
                    foreach (TVShow show in filler.FindMissingEpisodes())
                        Console.WriteLine("[{1:D2}x{2:D2}] {0}: {3}", show.Series, show.Season ?? 0, show.Episode ?? 0, show.Title);
                else
                    Console.WriteLine("Skipped");

                Console.WriteLine();
                Console.WriteLine("== List Missing Episode Links ==");

                // Finds links for all missing TVShows
                if (false)
                    foreach (String link in (from linkGroup
                                                 in filler.FindMissingEpisodeLinks(
                                                    (TVShow show) => new String[] { "Bones" }.Contains<String>(show.Series), 
                                                    null, 
                                                    delegate(TVShow show)
                                                    {
                                                        if (show.Series == "Castle (2009)")
                                                            show.Series = "Castle";
                                                        
                                                        if (show.Series == "Doctor Who (2005)")
                                                            show.Series = "Doctor Who";
                                                        
                                                        if (show.Series == "Battlestar Galactica (2003)")
                                                            show.Series = "Battlestar Galactica";
                                                        
                                                        if (show.Series == "American Dad!")
                                                            show.Series = "American Dad";

                                                        return show;
                                                    })
                                             from singleLink
                                                 in linkGroup.FirstOrDefault() ?? Enumerable.Empty<String>()
                                             select singleLink))
                        Console.WriteLine("{0}", link);
                else
                    Console.WriteLine("Skipped");

                Console.WriteLine();
                Console.WriteLine("== Waiting For Input ==");

                while (!Console.KeyAvailable)
                    Thread.Sleep(1000);
            }
        }
    }
}
