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
        public List<Image> image { get; set; }
        public string streamable { get; set; }
        public string ontour { get; set; }
        public Stats stats { get; set; }
        public Similar similar { get; set; }
        public Tags tags { get; set; }
        public Bio bio { get; set; }

        public ArtistI Current => throw new NotImplementedException();

        //object IEnumerator.Current => throw new NotImplementedException();

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