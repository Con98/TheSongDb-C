using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TheSongDb.Models.ArtistInfo;
using TheSongDb.Models.Top10;

namespace TheSongDb.Controllers
{
    public class MusicController : Controller
    {
        string BaseUrl = "http://ws.audioscrobbler.com/2.0/";
        string api_key = "581cca30b41a4cc0d5b3eb59d502b651";
        // GET: Music
        public async Task<ActionResult> Top10()
        {
            List<Artist> Top10Artists = new List<Artist>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("?method=chart.gettopartists&api_key=" + api_key + "&limit=10&format=json");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                    //Deserializing the response recieved from web api and storing into the Employee list 
                    var temp = new RootObject();
                    temp = JsonConvert.DeserializeObject<RootObject>(EmpResponse);

                    var myArtists = temp.artists.artist;

                    foreach (Artist a in myArtists)
                    {
                        Top10Artists.Add(a);
                    }

                }
            }
            return View(Top10Artists);
        }

        public async Task<ActionResult> ArtistInfo(string name)
        {

            ArtistI a = new ArtistI();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                name.Replace("\\s", "%20");
                HttpResponseMessage Res = await client.GetAsync("?method=artist.getinfo&artist=" + name + "&api_key=" + api_key + "&limit=10&format=json");

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    String jsonString = Res.Content.ReadAsStringAsync().Result;

                    var jo = JObject.Parse(jsonString);
                    //Getting name, mbid, url
                    String aName = jo["artist"]["name"].ToString();
                    String aMbid = jo["artist"]["mbid"].ToString();
                    String aUrl = jo["artist"]["url"].ToString();
                    //Getting image (Large)
                    String im = jo["artist"]["image"].ToString();
                    var ja = JArray.Parse(im);
                    var imSize = ja[3].ToString();
                    var imObj = JObject.Parse(imSize);
                    String imageUrl = imObj["#text"].ToString();
                    //Getting Stats
                    String aListeners = jo["artist"]["stats"]["listeners"].ToString();
                    String aPlaycount = jo["artist"]["stats"]["playcount"].ToString();
                    //Getting Bio
                    String aBio = jo["artist"]["bio"]["summary"].ToString();

                     a = new ArtistI(aName, aMbid, aUrl, imageUrl, aListeners, aPlaycount, aBio);
                }
            }
            return View(a);

        }

    }






}