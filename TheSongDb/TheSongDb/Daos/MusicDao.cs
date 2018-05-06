using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheSongDb.ViewModels;
using RestSharp;
using RestSharp.Deserializers;
namespace TheSongDb.Daos
    
{
    public class MusicDao
    {
        public List<Artist> getTopArtists { get; set; }
        RestClient client = new RestClient("http://ws.audioscrobbler.com/2.0/");
        RestRequest request = new RestRequest();

        request.AddParameter("method", myMethod);
        string myKey = "581cca30b41a4cc0d5b3eb59d502b651";
        request.AddParameter("api_key", myKey);

    }
}