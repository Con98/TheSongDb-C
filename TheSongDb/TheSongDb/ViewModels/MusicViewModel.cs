using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheSongDb.Models;

namespace TheSongDb.ViewModels
{
    public class MusicViewModel
    {
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Track Track { get; set; }
    }
}