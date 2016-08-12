namespace iTunes.Scrubber
{
    public abstract class Enums
    {
        public enum QualityEnum
        {
            SD = 0,
            HD_720 = 1,
            HD_1080 = 2
        };

        public enum MediaKindEnum
        {
            None = 0,
            Music = 1,
            Movie = 9,
            TVShow = 10,
            MusicVideo = 6,
        }

        public enum ForumEnum
        {
            Movies = 4,
            Music = 6,
            MusicVideos = 38,
            TVShows = 57,
        }

        public enum FormEnum
        {
            None = 0,
            Music = 1,
            Movie = 2,
            TVShow = 3,
            MusicVideo = 4,
            Main = 5,
        }

        public enum RatingEnum
        {
            Unknown = 0,
            G = 100,
            PG = 200,
            PG_13 = 300,
            PG_14 = 325,
            M = 350,
            MA = 375,
            R = 400,
            NC_17 = 500,
        }
    }
}
