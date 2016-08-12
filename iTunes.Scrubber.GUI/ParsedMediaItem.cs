using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Scrubber.GUI
{
    public class ParsedMediaItem<T> where T : BaseClasses.MediaBase<T>
    {
        public T Original { get; set; }
        public T Parsed { get; set; }

        public override String ToString()
        {
            return Parsed.ToString();
        }
    }
}
