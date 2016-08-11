using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    public class Summoner
    {
        public string Name { get; set; }
        public string ProfileIconId { get; set; }
        public string SummonerLevel { get; set; }
        public string Id { get; set; }
        public string RevisionDate { get; set; }


        public Summoner(string _name, string _profileIconId, string _summonerLevel, string _id, string _revisionDate)
        {
            Name = _name;
            ProfileIconId = _profileIconId;
            SummonerLevel = _summonerLevel;
            Id = _id;
            RevisionDate = _revisionDate;
            
        }

        public void printInfo()
        {

            Console.WriteLine(Name);
            Console.WriteLine(ProfileIconId);
            Console.WriteLine(SummonerLevel);
            Console.WriteLine(Id);
            Console.WriteLine(RevisionDate);

        }
    }
}
