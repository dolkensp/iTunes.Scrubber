using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Scrubber
{
    public class MetaData
    {
        public String Title { get; set; }
        public String Show { get; set; }
        public Int32? Season { get; set; }
        public Int32? Episode { get; set; }
        public Int16? TrackNo { get; set; }
        public String Description { get; set; }

        public String ShortDescription { get { return this.Description.Substring(0, Math.Min(this.Description.Length, 155)); } }

        public Boolean IsTVShow { get; set; }
        public Boolean IsHDVideo { get; set; }
    }
}
