using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models
{
    public class Artist
    {
        public string name { get; set; }
        public string playcount { get; set; }
        public string listeners { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public string streamable { get; set; }
        public List<Image> image { get; set; }
    }
}