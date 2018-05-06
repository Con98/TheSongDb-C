using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace TheSongDb.Controllers
{
    public class MusicController : Controller
    {
        string BaseUrl = "http://ws.audioscrobbler.com/2.0/";
        // GET: Music
        public async Task<ActionResult> Top10()
        {
            List<Artist> Top10Artists = new List<Artist>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("?method=chart.gettopartists&api_key=581cca30b41a4cc0d5b3eb59d502b651&limit=10&format=json");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                    //Deserializing the response recieved from web api and storing into the Employee list 
                    var temp = new RootObject();
                     temp = JsonConvert.DeserializeObject<RootObject>(EmpResponse);

                    var myArtists = temp.artists.artist;

                    foreach(Artist a in myArtists)
                    {
                        Top10Artists.Add(a);
                    }

                }
            }
                return View(Top10Artists);
        }
        
    }


    public class Image
    {
        public string text { get; set; }
    public string size { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string playcount { get; set; }
        public string listeners { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public string streamable { get; set; }
        public List<Image> image { get; set; }
    }

    public class Attr
    {
        public string page { get; set; }
        public string perPage { get; set; }
        public string totalPages { get; set; }
        public string total { get; set; }
    }

    public class Artists
    {
        public List<Artist> artist { get; set; }
        public Attr attr { get; set; }

    }
public class RootObject
{
    public Artists artists { get; set; }
}
}