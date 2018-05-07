using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models.ArtistInfo
{

    public class Bio
    {
        public Links links { get; set; }
        public string published { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }
}