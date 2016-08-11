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
    public partial class Form1 : Form
    {
        HttpClient HC = new HttpClient();
      //  List<Champion> champs = new List<Champion>();
    

        static string SUMMONER_INFO_REQUEST = "https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/";
        static string API_KEY = "?api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a";
        static string CHAMPION_MASTERY_REQUEST = "https://na.api.pvp.net/championmastery/location/NA1/player/";


        public Form1()
        {
            InitializeComponent();
            AllChampData acd = new AllChampData();
           // Console.WriteLine(AllChampData.CHAMPS[1].Armor);

            champBox.DataSource = AllChampData.CHAMPS;
            champBox.DisplayMember = "Name";

            //getChampDataOnLoad();

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile("http://ddragon.leagueoflegends.com/cdn/6.15.1/img/champion/Annie.png", "Annie.png");
            }

            Bitmap image = new Bitmap("Annie.png");
            pictureBox1.Image = image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Summoner sum = getSummonerInfo(SumNameTextBox.Text);


            //below might all be worthless because i wrote a new method to get summoner info and returns a new class i wrote called summoner
            // that will have all the info returned by riot.

            /* righ now im not sure how Web requests work and at some point i really need to figure out what they do and how they 
             * work.  At the moment just trying to get some code running
             

            string summonerName = SumNameTextBox.Text;
            var request = (HttpWebRequest)WebRequest.Create("https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/"+ summonerName + "?api_key=2c80011d-173e-4a9a-b040-b04f7f8edf9a");
          

            

            try
            {
                // this is what is getting info from riots shit
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                
                // using a stream reader to simply read the whole text.  Since this is such a small ammount of text im fine with this atm.

                string idunno = reader.ReadToEnd();
                outputBox.Clear();
                outputBox.Text = idunno;

                // Console.WriteLine(idunno);
            
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Error: " + ex.ToString(), "Error Box");
            }
            */

            
        }

        private void getChampData_Click(object sender, EventArgs e)
        {

            /* ok.  So this should download the json file from Riot (wont need to do this later, just this data pre-made).
             * Right now im only printing the data out.  Next step is to make a new class to hold all the data im getting
             * 
             * REMEMBER how this shit works, or at least how you think it does. its a simple hierarchy of 'o' being the parsed file
             * data being the the data is - > name of champ (the k since it was easy to get  list of of the names) -> get all the data i would need
             * for now (id, title)
             */

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/6.15.1/data/en_US/champion.json");
                Console.WriteLine("I think it worked");

                //  var reader = new StreamReader(json);

                JObject o = JObject.Parse(json);
                JObject inner = o["data"].Value<JObject>();

                List<string> keys = inner.Properties().Select(p => p.Name).ToList();

                foreach (string k in keys)
                {
                    
                    // this makes a list of champions with the name, title, and id

                    /*
                     * figure out why this doesnt work at some point
                     * 
                     * IS IT JUST A TYPO OR WTF
                     * 
                    champs.Add(new Champion(k, (string)o["data"][k]["title"], (int)o["data"][k]["key"], (double)o["data"][k]["stats"]["hp"],
                                (double)o["data"][k]["stats"]["hpperlevel"], (double)o["data"][k]["stats"]["mp"], (double)o["data"][k]["stats"]["mpperlevel"],
                                (double)o["data"][k]["stats"]["movespeed"], (double)o["data"][k]["stats"]["armor"], (double)o["data"][k]["stats"]["armorperlevel"],
                                (double)o["data"][k]["stats"]["spellblock"], (double)o["data"][k]["stats"]["spellblockperlevel"], (double)o["data"][k]["stats"]["attackrange"],
                                (double)o["data"][k]["stats"]["hpregen"], (double)o["data"][k]["stats"]["hpregenperlevel"], (double)o["data"][k]["stats"]["mpregen"],
                                (double)o["data"][k]["stats"]["mpregenperlevel"], (double)o["data"][k]["stats"]["crit"], (double)o["data"][k]["stats"]["critperlevel"],
                                (double)o["data"][k]["stats"]["attackdamage"], (double)o["data"][k]["stats"]["attackdamgeperlevel"], (double)o["data"][k]["stats"]["attackspeedoffset"],
                                (double)o["data"][k]["stats"]["attackspeedperlevel"]));
                    */

                }

                //after we make a list lets fill out the combo box so you can select champs and get the data from the selected champ

                //champBox.DataSource = champs;
               // champBox.DisplayMember = "Name";               
             
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //Champion ashe = new Champion("Ashe", "The Frost Archer", 12);
            //Console.WriteLine(ashe.name + ashe.title + ashe.id);
            foreach (Champion c in AllChampData.CHAMPS)
            {
                Console.WriteLine(c.Name + " " + c.Title + " " + c.Id);
            }
        }

        private void champBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Champion temp = AllChampData.CHAMPS[champBox.SelectedIndex];
            string test = temp.ReturnInfoToString();
            outputBox.Text = test;
            
        }


        // tries to check the mastery of the Champion selected and the Summoner selected
        private void checkMasteryButton_Click(object sender, EventArgs e)
        {
            string summonerName = SumNameTextBox.Text;
            Summoner sum = getSummonerInfo(summonerName);
            Champion champ = AllChampData.CHAMPS[champBox.SelectedIndex];
            
            try
            {
       
                using (WebClient wc = new WebClient())
                {

                    var json = wc.DownloadString(CHAMPION_MASTERY_REQUEST + sum.Id + "/champion/" + champ.Id + API_KEY);
                    JObject o = JObject.Parse(json);
                    outputBox.Text = "Champion Mastery Points: " + (string)o["championPoints"] + ".  Champion Level: " + (string)o["championLevel"];

                }
 
            }
            catch (Exception ex) { MessageBox.Show(sum.Name + " has no mastery for champion " + champ.Name, "Error Box"); }

           
        }

        //this function returns basic summoner info i a simple string
        public Summoner getSummonerInfo (string summonerName)
        {
            summonerName = summonerName.ToLower();

            using (WebClient wc = new WebClient())
            {

                try
                {
                    var json = wc.DownloadString(SUMMONER_INFO_REQUEST + summonerName + API_KEY);
                    JObject o = JObject.Parse(json);


                    Summoner summoner = new Summoner((string)o[summonerName]["name"],
                                                            (string)o[summonerName]["profileIconId"],
                                                            (string)o[summonerName]["summonerLevel"],
                                                            (string)o[summonerName]["id"],
                                                            (string)o[summonerName]["revisionDate"]);
                    summoner.printInfo();

                    return summoner;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString(), "Error Box");
                    Summoner failed = new Summoner("failed", "failed", "failed", "failed", "failed");
                    return failed;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string getName = SumNameTextBox.Text;
            if (getName == null || getName == "")
            {
                RankedStats test = new RankedStats("eggbeater");
            }
            else
            {
                RankedStats test = new RankedStats(getName);
            }
        }

        //gets champion data on loading the app.  Right now this is done via riots api.  Someday I might check versions and only download when new.

        
            // this has been moved to a static class so the whole project can get access to it

            /*
        private void getChampDataOnLoad()
        {

            /* ok.  So this should download the json file from Riot (wont need to do this later, just this data pre-made).
             * Right now im only printing the data out.  Next step is to make a new class to hold all the data im getting
             * 
             * REMEMBER how this shit works, or at least how you think it does. its a simple hierarchy of 'o' being the parsed file
             * data being the the data is - > name of champ (the k since it was easy to get  list of of the names) -> get all the data i would need
             * for now (id, title)
             

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/6.15.1/data/en_US/champion.json");
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
                    double movespeed = (double)o["data"][k]["stats"]["armor"];
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

                    champs.Add(new Champion( k,  title,  id,  hp
                     ,  hpperlevel,  mp,  mpperlevel,  movespeed,  armor,  armorperlevel
                     ,  spellblock,  spellblockperlevel,  attackrange,  hpregen,  hpregenperlevel,  mpregen,  mpregenperlevel,  crit
                     ,  critperlevel,  attackdamage,  attackdamageperlevel,  attackspeedoffset,  attackspeedperlevel));
                }

                //after we make a list lets fill out the combo box so you can select champs and get the data from the selected champ

                champBox.DataSource = champs;
                champBox.DisplayMember = "Name";

            } */
        }
    }


