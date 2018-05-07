using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models.ArtistInfo
{
    public class Artist2
    {
        public string name { get; set; }
        public string url { get; set; }
        public List<Image2> image { get; set; }
    }
}