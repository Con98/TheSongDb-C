﻿using System;
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


        public ArtistI()
        {

        //object IEnumerator.Current => throw new NotImplementedException();


        }
        public ArtistI(String name, String url, String image, String listeners, String playCount, String bio)
        {
            this.name = name;
            
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