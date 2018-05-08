using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheSongDb.Models.ArtistInfo
{
    public class ArtistI 
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public String image { get; set; }
        public String listeners { get; set; }
        public String playCount { get; set; }
        public String bio { get; set; }

        public ArtistI Current => throw new NotImplementedException();

<<<<<<< HEAD
        public ArtistI()
        {
=======
        //object IEnumerator.Current => throw new NotImplementedException();
>>>>>>> 6b316cc9dadac252bd859a8070e5595cd503e330

        }
        public ArtistI(String name, String mbid, String url, String image, String listeners, String playcount, String bio)
        {
            this.name = name;
            this.mbid = mbid;
            this.url = url;
            this.image = image;
            this.listeners = listeners;
            this.playCount = playCount;
            this.bio = bio;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

}