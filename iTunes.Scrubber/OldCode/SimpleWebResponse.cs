using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Scrubber
{
    public class SimpleWebResponse
    {
        public Dictionary<String, String> Headers { get; set; }
        public Dictionary<String, String> Cookies { get; set; }
        public String Content { get; set; }
    }
}
