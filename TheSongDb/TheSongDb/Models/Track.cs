using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models
{
    public class Track
    {
        public String name { get; set; }
        public String url { get; set; }
        public String genre { get; set; }
        public String genreUrl { get; set; }
        public String imageUrl { get; set; }

    }
}