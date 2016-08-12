using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Scrubber
{
    public class TVShow
    {
        public Int32? PersistentHigh { get; set; }
        public Int32? PersistentLow { get; set; }
        public Int32? VideoHeight { get; set; }
        public Int32? VideoWidth { get; set; }
        public Int32? Episode { get; set; }
        public Int32? Season { get; set; }
        
        public String Series { get; set; }
        public String Title { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
