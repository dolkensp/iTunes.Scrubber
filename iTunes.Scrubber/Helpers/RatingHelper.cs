using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Scrubber.Helpers
{
    public static class RatingHelper
    {
        public static String GetAURating(String countryCode, String rating)
        {
            switch (countryCode.ToLowerInvariant())
            {
                case "au":
                    switch (rating.ToLowerInvariant())
                    {
                        case "g":        return "au-movie|G|100|For all ages";
                        case "pg":       return "au-movie|PG|200|Parental Guidance Recommended";
                        case "m":        return "au-movie|M|350|Recommended for ages 15 and over";
                        case "ma15+":    return "au-movie|MA|375|Restricted to ages 15 and over";
                        case "ma":       return "au-movie|MA|375|Restricted to ages 15 and over";
                        case "r":        return "au-movie|R|400|Restricted to ages 18 and over";
                        case "(banned)": return "au-movie|Banned|600|This movie is banned in Australia";
                        case "unrated":  return "au-movie|Unrated|???|This content is unrated";
                    }
                    break;
                case "nz":
                    switch (rating.ToLowerInvariant())
                    {
                        case "g":        return "au-movie|G|100|For all ages";
                        case "pg":       return "au-movie|PG|200|Parental Guidance Recommended";
                        case "m":        return "au-movie|M|350|Recommended for ages 15 and over";
                        case "r13":      return "au-movie|M|350|Recommended for ages 15 and over";
                        case "r15":      return "au-movie|MA|375|Restricted to ages 15 and over";
                        case "r16":      return "au-movie|MA|375|Restricted to ages 15 and over";
                        case "r18":      return "au-movie|R|400|Restricted to ages 18 and over";
                        case "r":        return "au-movie|R|400|Restricted to ages 18 and over";
                        case "(banned)": return "au-movie|Banned|600|This movie is banned in Australia";
                        case "unrated":  return "au-movie|Unrated|???|This content is unrated";
                    }
                    break;
                case "gb":
                    switch (rating.ToLowerInvariant())
                    {
                        case "u":        return "au-movie|G|100|For all ages";
                        case "uc":       return "au-movie|G|100|For all ages";
                        case "pg":       return "au-movie|PG|200|Parental Guidance Recommended";
                        case "12":       return "au-movie|PG|200|Parental Guidance Recommended";
                        case "15":       return "au-movie|M|350|Recommended for ages 15 and over";
                        case "18":       return "au-movie|R|400|Restricted to ages 18 and over";
                        case "e":        return "au-movie|G|100|For all ages";
                        case "(banned)": return "au-movie|Banned|600|This movie is banned in Australia";
                        case "unrated":  return "au-movie|Unrated|???|This content is unrated";
                    }
                    break;
                case "us":
                    switch (rating.ToLowerInvariant())
                    {
                        case "g":        return "au-movie|G|100|For all ages";
                        case "pg":       return "au-movie|PG|200|Parental Guidance Recommended";
                        case "pg-13":    return "au-movie|M|350|Recommended for ages 15 and over";
                        case "nc-17":    return "au-movie|MA|375|Restricted to ages 15 and over";
                        case "r":        return "au-movie|R|400|Restricted to ages 18 and over";
                        case "(banned)": return "au-movie|Banned|600|This movie is banned in Australia";
                        case "unrated":  return "au-movie|Unrated|???|This content is unrated";
                    }
                    break;
            }

            Console.WriteLine("Unknown Classification [{0}:{1}]", countryCode, rating);

            return "au-movie|Unrated|???|This content is unrated";
        }

        public static String Parse(String rating)
        {
            switch (rating)
            {
                case "NR":
                case "C":
                    return "mpaa|C|000|This show is for children";
                case "G":
                case "TV_G":
                    return "mpaa|G|100|For all ages";
                case "PG":
                case "PG_13":
                case "PG-13":
                    return "mpaa|PG|200|Parental Guidance recommended";
                case "M":
                    return "mpaa|M|325|Recommended for ages 15 and over";
                case "MA":
                    return "mpaa|MA|350|Restricted to ages 15 and over";
                case "R":
                case "NC-17":
                case "NC_17":
                    return "mpaa|R18+|400|Restricted to adult audiences";
                default:
                    return "mpaa|Unrated|???|This content is unrated";
            }
        }
    }
}
