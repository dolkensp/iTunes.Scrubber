using System;

namespace iTunes.Scrubber
{
    public abstract class Constants
    {
        public const String IMDB_TVTITLE = "//meta[@itemprop='episodeNumber' and @content='{1}']//following-sibling::strong/a[@itemprop='name']";
        public const String IMDB_TVDESCRIPTION = "//meta[@itemprop='episodeNumber' and @content='{1}']//following-sibling::div[@itemprop='description']";

        /// <summary>
        /// XPath used to get the Episode from the IMDB Episodes List.
        /// </summary>
        public const String IMDB_EPISODE = "//div/div//h3[contains(text(), 'Episode')]/a";

        public const String IMDB_MOVIETITLE = "//h1[@class='header']";
        public const String IMDB_MOVIEYEAR = "//h1[@class='header']/span/a";
        public const String IMDB_MOVIEGENRES = "//div[@class='infobar']/a";
        public const String IMDB_MOVIERATING = "//div[@class='infobar']/img";
        public const String IMDB_MOVIESYNOPSIS = "//td[@id='overview-top']/p";

        /// <summary>
        /// Time (in seconds) between searches on warez-bb.org
        /// </summary>
        public const Int32 WAREZBB_THROTTLE = 30;
        /// <summary>
        /// Pipe seperated list of tags to check for download links
        /// </summary>
        public const String WAREZBB_TAGS = "FSC|HF|FS";
        /// <summary>
        /// Pipe seperated list of hosts to accept download links for
        /// </summary>
        public const String WAREZBB_HOSTS = "filesonic|hotfile|fileserve";
        /// <summary>
        /// Number of searches allowed per hour on deanclatworthy.com
        /// </summary>
        public const Int32 IMDBAPI_THROTTLE = 30;

        /// <summary>
        /// Flag used to indicate metadata shouldn't be updated, we're just doing a test run.
        /// </summary>
        public static Boolean NOCHANGES = false;
        public static Boolean CHANGEART = false;
    }
}

/*
static const iTMF_rating_t rating_strings[] = {
    {"mpaa|NR|000|", "Not Rated"},          // 0
    {"mpaa|G|100|", "G"},
    {"mpaa|PG|200|", "PG"},
    {"mpaa|PG-13|300|", "PG-13"},
    {"mpaa|R|400|", "R" },
    {"mpaa|NC-17|500|", "NC-17"},
    {"mpaa|Unrated|???|", "Unrated"},
    {"", ""},
    {"us-tv|TV-Y|100|", "TV-Y"},            // 8
    {"us-tv|TV-Y7|200|", "TV-Y7"},
    {"us-tv|TV-G|300|", "TV-G"},
    {"us-tv|TV-PG|400|", "TV-PG"},
    {"us-tv|TV-14|500|", "TV-14"},
    {"us-tv|TV-MA|600|", "TV-MA"},
    {"us-tv|Unrated|???|", "Unrated"},
    {"", ""},
    {"uk-movie|NR|000|", "Not Rated"},      // 16
    {"uk-movie|U|100|", "U"},
    {"uk-movie|Uc|150|", "Uc"},
    {"uk-movie|PG|200|", "PG"},
    {"uk-movie|12|300|", "12"},
    {"uk-movie|12A|325|", "12A"},
    {"uk-movie|15|350|", "15"},
    {"uk-movie|18|400|", "18"},
    {"uk-movie|R18|600|", "R18"},
    {"uk-movie|E|0|", "Exempt" },
    {"uk-movie|Unrated|???|", "Unrated"},
    {"", ""},
    {"uk-tv|Caution|500|", "Caution"},      // 28
    {"", ""},
    {"de-movie|FSK 0|100|", "FSK 0"},           // 30
    {"de-movie|FSK 6|200|", "FSK 6"},
    {"de-movie|FSK 12|300|", "FSK 12"},
    {"de-movie|FSK 16|400|", "FSK 16"},
    {"de-movie|FSK 18|500|", "FSK 18"},
    {"", ""},
    {"", "Unknown"},                        // 36
    {NULL, NULL},
};
*/