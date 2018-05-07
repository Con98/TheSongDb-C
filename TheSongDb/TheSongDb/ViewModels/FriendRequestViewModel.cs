using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheSongDb.Models;

namespace TheSongDb.ViewModels
{
    public class FriendRequestViewModel
    {
        public User User { get; set; }
        public Friend Friend { get; set; }
    }
}