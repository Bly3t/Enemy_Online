using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Json.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace enemyOnline
{
    class Enemy
    {
        public const string URL = "https://api.tibiadata.com/v2/world/Refugia.json";
        public static List<String> PlayerList_Online = new List<String>(); // All online players
        public static List<String> RunApi()
        {

            var player = new HttpClient();
            player.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = player.GetAsync("https://api.tibiadata.com/v2/world/Refugia.json").Result;
            if (response.IsSuccessStatusCode)
            {
                var enemy = response.Content.ReadAsStringAsync().Result;
                Root Enemy = JsonConvert.DeserializeObject<Root>(enemy);
                foreach (var item in Enemy.world.players_online)
                {
                    PlayerList_Online.Add(item.name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return PlayerList_Online;

        }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Date
    {
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("timezone_type")]
        public int timezone_type { get; set; }
        [JsonProperty("timezone")]
        public string timezone { get; set; }

    }

    public class OnlineRecord
    {
        [JsonProperty("players")]
        public int players { get; set; }
        [JsonProperty("date")]
        public Date date { get; set; }

    }

    public class WorldInformation
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("players_online")]
        public int players_online { get; set; }
        [JsonProperty("online_record")]
        public OnlineRecord online_record { get; set; }
        [JsonProperty("creation_date")]
        public string creation_date { get; set; }
        [JsonProperty("location")]
        public string location { get; set; }
        [JsonProperty("pvp_type")]
        public string pvp_type { get; set; }
        [JsonProperty("world_quest_titles")]
        public List<string> world_quest_titles { get; set; }
        [JsonProperty("battleye_status")]
        public string battleye_status { get; set; }

}

public class PlayersOnline
{
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("level")]
    public int level { get; set; }
    [JsonProperty("vocation")]
    public string vocation { get; set; }

}

public class World
{
    [JsonProperty("world_information")]
    public WorldInformation world_information { get; set; }
    [JsonProperty("players_online")]
    public List<PlayersOnline> players_online { get; set; }

}

public class Information
{
    [JsonProperty("api_version")]
    public int api_version { get; set; }
    [JsonProperty("execution_time")]
    public double execution_time { get; set; }
    [JsonProperty("last_updated")]
    public string last_updated { get; set; }
    [JsonProperty("timestamp")]
    public string timestamp { get; set; }

}

public class Root
{
    [JsonProperty("world")]
    public World world { get; set; }
    [JsonProperty("information")]
    public Information information { get; set; }

}

}