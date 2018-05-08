using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TheSongDb.Models
{
    [Bind(Exclude = "User")]
    public class Friend
    {
        public int friendId { get; set; }
        //public User User { get; set; }
        public String friend1 { get; set; }
        public String friend2 { get; set; }
    }
}