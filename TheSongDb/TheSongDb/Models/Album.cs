using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models
{
    public class Album
    {
        public String image { get; set; }
        public String largeImage { get; set; }
        public String name { get; set; }
        public int playcount { get; set; }
        public String url { get; set; }
        public String release { get; set; }
        public String artist { get; set; }
    }
}