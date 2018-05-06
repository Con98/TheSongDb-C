using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models
{
    public class User
    {
        public int userId { get; set; }
        public String firstName { get; set; }
        public String surname { get; set; }
        public String userName { get; set; }
        public String email { get; set; }
        public String password { get; set; }
    }
}