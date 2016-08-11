using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lol
{
    public class RankedStatsChampStats
    {
        #region lots of decs
            public int deaths { get; set; }
            public int sessionsPlayed { get; set; }
            public int damageTaken { get; set; }
            public int quadraKills { get; set; }
            public int tripleKills { get; set; }
            public int minionKills { get; set; }
            public int maxChampionsKilled { get; set; }
            public int doubleKills { get; set; }
            public int physicalDamageDealt { get; set; }
            public int championKills { get; set; }
            public int assists  { get; set; }
            public int mostChampionKillsPerSession { get; set; }
            public int damageDealt { get; set; }
            public int firstBlood { get; set; }
            public int sessionsLost { get; set; }
            public int sessionsWon { get; set; }
            public int magicDamageDealt { get; set; }
            public int goldEarned  { get; set; }
            public int pentaKills  { get; set; }
            public int turretsKilled { get; set; } 
            public int mostSpellsCast  { get; set; }
            public int maxNumDeaths  { get; set; }
            public int unrealKills { get; set; }
            public int champId { get; set; }
            public string champName { get; set; }
        #endregion

        public RankedStatsChampStats(JToken jObject)
        {

            champId = (int)jObject["id"];
            if(champId == 0)
            {
                champName = "Totals for all champs";
            }
            else
            {
                //this is still dumb doing it again, but cycling through all the champs checking ids to find the champs name

                for(int i = 0; i < AllChampData.CHAMPS.Count; i++)
                {
                    if (champId == AllChampData.CHAMPS[i].Id)
                        champName = AllChampData.CHAMPS[i].Name;
                }
            }

            #region lots of instantiations
            deaths = int.Parse((string)jObject["stats"]["totalDeathsPerSession"]);
            sessionsPlayed = int.Parse((string)jObject["stats"]["totalSessionsPlayed"]);
            damageTaken = int.Parse((string)jObject["stats"]["totalDamageTaken"]);
            quadraKills = int.Parse((string)jObject["stats"]["totalQuadraKills"]);
            tripleKills = int.Parse((string)jObject["stats"]["totalTripleKills"]);
            minionKills = int.Parse((string)jObject["stats"]["totalMinionKills"]);
            championKills = int.Parse((string)jObject["stats"]["maxChampionsKilled"]);
            doubleKills = int.Parse((string)jObject["stats"]["totalDoubleKills"]);
            physicalDamageDealt = int.Parse((string)jObject["stats"]["totalPhysicalDamageDealt"]);
            championKills = int.Parse((string)jObject["stats"]["totalChampionKills"]);
            assists = int.Parse((string)jObject["stats"]["totalAssists"]);
            mostChampionKillsPerSession = int.Parse((string)jObject["stats"]["mostChampionKillsPerSession"]);
            damageDealt = int.Parse((string)jObject["stats"]["totalDamageDealt"]);
            firstBlood = int.Parse((string)jObject["stats"]["totalFirstBlood"]);
            sessionsLost = int.Parse((string)jObject["stats"]["totalSessionsLost"]);
            sessionsWon = int.Parse((string)jObject["stats"]["totalSessionsWon"]);
            magicDamageDealt = int.Parse((string)jObject["stats"]["totalMagicDamageDealt"]);
            goldEarned = int.Parse((string)jObject["stats"]["totalGoldEarned"]);
            pentaKills = int.Parse((string)jObject["stats"]["totalPentaKills"]);
            turretsKilled = int.Parse((string)jObject["stats"]["totalTurretsKilled"]);
            mostSpellsCast = int.Parse((string)jObject["stats"]["mostSpellsCast"]);
            maxNumDeaths = int.Parse((string)jObject["stats"]["maxNumDeaths"]);
            unrealKills = int.Parse((string)jObject["stats"]["totalUnrealKills"]);
            #endregion

        }


    }  
}
