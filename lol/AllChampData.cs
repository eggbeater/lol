using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lol
{
    class AllChampData
    {
        public static List<Champion> CHAMPS;
        public AllChampData()
        
        {
            using (WebClient wc = new WebClient())
            {
                CHAMPS = new List<Champion>();
                var json = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/6.16.2/data/en_US/champion.json");
                Console.WriteLine("I think it worked");

                //  var reader = new StreamReader(json);

                JObject o = JObject.Parse(json);
                JObject inner = o["data"].Value<JObject>();



                List<string> keys = inner.Properties().Select(p => p.Name).ToList();

                foreach (string k in keys)
                {

                    // this makes a list of champions with the name, title, and id
                    // as of now i dont know why i had to do it this way, i shouldnt have to instantiate new variables, just put them in the constructor... w/e

                    string title = (string)o["data"][k]["title"];
                    int id = (int)o["data"][k]["key"];

                    double hp = (double)o["data"][k]["stats"]["hp"];
                    double hpperlevel = (double)o["data"][k]["stats"]["hpperlevel"];
                    double mp = (double)o["data"][k]["stats"]["mp"];
                    double mpperlevel = (double)o["data"][k]["stats"]["mpperlevel"];
                    double movespeed = (double)o["data"][k]["stats"]["movespeed"];
                    double armor = (double)o["data"][k]["stats"]["armor"];
                    double armorperlevel = (double)o["data"][k]["stats"]["armorperlevel"];
                    double spellblock = (double)o["data"][k]["stats"]["spellblock"];
                    double spellblockperlevel = (double)o["data"][k]["stats"]["spellblockperlevel"];
                    double attackrange = (double)o["data"][k]["stats"]["attackrange"];
                    double hpregen = (double)o["data"][k]["stats"]["hpregen"];
                    double hpregenperlevel = (double)o["data"][k]["stats"]["hpregenperlevel"];
                    double mpregen = (double)o["data"][k]["stats"]["mpregen"];
                    double mpregenperlevel = (double)o["data"][k]["stats"]["mpregenperlevel"];
                    double crit = (double)o["data"][k]["stats"]["crit"];
                    double critperlevel = (double)o["data"][k]["stats"]["critperlevel"];
                    double attackdamage = (double)o["data"][k]["stats"]["attackdamage"];
                    double attackdamageperlevel = (double)o["data"][k]["stats"]["attackdamageperlevel"];
                    double attackspeedoffset = (double)o["data"][k]["stats"]["attackspeedoffset"];
                    double attackspeedperlevel = (double)o["data"][k]["stats"]["attackspeedperlevel"];


                    //CHAMPS.Add
                        
                     Champion champ =    (new Champion(k, title, id, hp

                     , hpperlevel, mp, mpperlevel, movespeed, armor, armorperlevel

                     , spellblock, spellblockperlevel, attackrange, hpregen, hpregenperlevel, mpregen, mpregenperlevel, crit

                     , critperlevel, attackdamage, attackdamageperlevel, attackspeedoffset, attackspeedperlevel));

                    CHAMPS.Add(champ);
                }
            }
        }
    }
}
