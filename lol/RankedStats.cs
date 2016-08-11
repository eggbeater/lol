using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/* right now this class takes a summoner name and then finds all the ranked games they have played this season.
 * The data is currently stored by making a list of 'stats'
 * stats is a dictionary with the key being the stat name and the value being the stat
 * the first 'stat' is champion name because the api only returns the champ id which I then find what champ that is with a new static class i made
 * called AllChampData.  
 * 
 * Currently this class does nothing besides put all the stats in a list
 * 
 * 
 * after working with some of the data it might wise to make another class or something to get to this data easier.  right now i have to 
 * remember all the keywords for the dictionary and that seems pretty dumb
 */
 
namespace lol
{
    public class RankedStats
    {
       // public List<Champion> allChamps;
        
        public List<Dictionary<string, string>> listOfStats { get; set; }
        public List<RankedStatsChampStats> list { get; set; }
        public string champName;
        public string sumName { get; set; }

        

        public RankedStats(string _summonerName)
        {
           // stats = new Dictionary<string, string>();
            listOfStats = new List<Dictionary<string, string>>();
            list = new List<RankedStatsChampStats>();
            sumName = _summonerName;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/" + _summonerName + "?api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a");
                JObject o = JObject.Parse(json);
                string id1 = (string)o[_summonerName]["id"];

                var json2 = wc.DownloadString("https://na.api.pvp.net/api/lol/na/v1.3/stats/by-summoner/" + id1 + "/ranked?season=SEASON2016&api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a");
                JObject o2 = JObject.Parse(json2);

                var test = o2["champions"];

                foreach(var JObject in test)
                {
                    list.Add(new RankedStatsChampStats(JObject));
                }
            }

            List<RankedStatsChampStats> list2 = list.OrderBy(x => x.sessionsPlayed).ToList();

            RankedStatsWindow rsw = new RankedStatsWindow(this, sumName);

            #region oldcode
            /*
            using (WebClient wc = new WebClient())
            {
                //need to get summoner ID to look up other things, this could prolly be handled better.  
                var json = wc.DownloadString("https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/" + _summonerName + "?api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a");
                JObject o = JObject.Parse(json);
                string id1 = (string)o[_summonerName]["id"];

                var json2 = wc.DownloadString("https://na.api.pvp.net/api/lol/na/v1.3/stats/by-summoner/" + id1 + "/ranked?season=SEASON2016&api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a");
                JObject o2 = JObject.Parse(json2);

                var test = o2["champions"];

               

                foreach(var jObject in test)
                {
                    int id = (int)jObject["id"];
                    
                    //this is a really dumb way of doing this, look for a better solution

                    for (int i = 0; i < AllChampData.CHAMPS.Count; i++)
                    {
                        if (id == AllChampData.CHAMPS[i].Id)
                        {
                            Console.WriteLine(AllChampData.CHAMPS[i].Name);
                            Dictionary<string, string> stats = new Dictionary<string, string>();

                            stats.Add("Champion Name", AllChampData.CHAMPS[i].Name);
                            stats.Add("totalDeathsPerSession", (string)jObject["stats"]["totalDeathsPerSession"]);
                            stats.Add("totalSessionsPlayed", (string)jObject["stats"]["totalSessionsPlayed"]);
                            stats.Add("totalDamageTaken", (string)jObject["stats"]["totalDamageTaken"]);
                            stats.Add("totalQuadraKills", (string)jObject["stats"]["totalQuadraKills"]);
                            stats.Add("totalTripleKills", (string)jObject["stats"]["totalTripleKills"]);
                            stats.Add("totalMinionKills", (string)jObject["stats"]["totalMinionKills"]);
                            stats.Add("maxChampionsKilled", (string)jObject["stats"]["maxChampionsKilled"]);
                            stats.Add("totalDoubleKills", (string)jObject["stats"]["totalDoubleKills"]);
                            stats.Add("totalPhysicalDamageDealt", (string)jObject["stats"]["totalPhysicalDamageDealt"]);
                            stats.Add("totalChampionKills", (string)jObject["stats"]["totalChampionKills"]);
                            stats.Add("totalAssists", (string)jObject["stats"]["totalAssists"]);
                            stats.Add("mostChampionKillsPerSession", (string)jObject["stats"]["mostChampionKillsPerSession"]);
                            stats.Add("totalDamageDealt", (string)jObject["stats"]["totalDamageDealt"]);
                            stats.Add("totalFirstBlood", (string)jObject["stats"]["totalFirstBlood"]);

                            stats.Add("totalSessionsLost", (string)jObject["stats"]["totalSessionsLost"]);
                            totalLosses += (int)jObject["stats"]["totalSessionsLost"];
                            stats.Add("totalSessionsWon", (string)jObject["stats"]["totalSessionsWon"]);
                            totalWins += (int)jObject["stats"]["totalSessionsWon"];

                            stats.Add("totalMagicDamageDealt", (string)jObject["stats"]["totalMagicDamageDealt"]);
                            stats.Add("totalGoldEarned", (string)jObject["stats"]["totalGoldEarned"]);
                            stats.Add("totalPentaKills", (string)jObject["stats"]["totalPentaKills"]);
                            stats.Add("totalTurretsKilled", (string)jObject["stats"]["totalTurretsKilled"]);
                            stats.Add("mostSpellsCast", (string)jObject["stats"]["mostSpellsCast"]);
                            stats.Add("maxNumDeaths", (string)jObject["stats"]["maxNumDeaths"]);
                            stats.Add("totalUnrealKills", (string)jObject["stats"]["totalUnrealKills"]);


                            listOfStats.Add(stats);
                        }
                    }
                }                          
            }

            Console.WriteLine("losses: " + totalLosses); Console.WriteLine("wins: " + totalWins);

            RankedStatsWindow openNewWindow = new RankedStatsWindow(this);

    */
            #endregion
        }
    }
}
