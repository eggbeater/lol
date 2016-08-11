using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lol
{
//# KEYWORDS 
//            "totalDeathsPerSession"
//            "totalSessionsPlayed"
//            "totalDamageTaken":
//            "totalQuadraKills":
//            "totalTripleKills":
//            "totalMinionKills": 
//            "maxChampionsKilled": 
//            "totalDoubleKills": 
//            "totalPhysicalDamageDealt"
//            "totalChampionKills"
//            "totalAssists": 
//            "mostChampionKillsPerSession"
//            "totalDamageDealt"
//            "totalFirstBlood"
//            "totalSessionsLost"
//            "totalSessionsWon"
//            "totalMagicDamageDealt"
//            "totalGoldEarned": 
//            "totalPentaKills": 
//            "totalTurretsKilled": 
//            "mostSpellsCast": 
//            "maxNumDeaths": 
//            "totalUnrealKills"

    public partial class RankedStatsWindow : Form
    {

        public RankedStatsWindow(RankedStats rs, string _summonerName)
        {
            InitializeComponent();
            this.Show();



            _summonerName = _summonerName.First().ToString().ToUpper() + _summonerName.Substring(1);
            //sorts all the ranked stats by most played.  because of how riot works the most played will be total values of all champs played
            List<RankedStatsChampStats> stats = rs.list.OrderByDescending(x => x.sessionsPlayed).ToList();

            winsLabel.Text = "Total Wins: " + stats[0].sessionsWon;
            lossesLabel.Text = "Total Losses" + stats[0].sessionsLost;
            kdaLabel.Text = String.Format("KDA: {0} - {1} - {2}", stats[0].championKills, stats[0].deaths, stats[0].assists);
            double kda = (((double)stats[0].championKills + (double)stats[0].assists) / (double)stats[0].deaths);
            Console.WriteLine(kda);
            this.Text = _summonerName + "'s Ranked Stats";

            //    listView1.Columns.Add("Champion", 150);
            //   listView1.Columns.Add("Games Played", 150);

            listView1.Columns.Add("Champion", 100);
            listView1.Columns.Add("Games Played", 70);
            listView1.Columns.Add("Games Won", 70);
            listView1.Columns.Add("Games Lost", 70);
            listView1.Columns.Add("Kills", 70);
            listView1.Columns.Add("Deaths", 70);
            listView1.Columns.Add("Assists", 70);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            ListViewItem itm;

            for (int i = 1; i < stats.Count; i++)
            {
                  string[] arr = new string[7];
                  arr[0] = stats[i].champName;
                  arr[1] = stats[i].sessionsPlayed.ToString();
                  arr[2] = stats[i].sessionsWon.ToString();
                  arr[3] = stats[i].sessionsLost.ToString();
                  arr[4] = stats[i].championKills.ToString();
                  arr[5] = stats[i].deaths.ToString();
                  arr[6] = stats[i].assists.ToString();

                  itm = new ListViewItem(arr);
                  listView1.Items.Add(itm); 

              


            }

            //old code for putting in rich text box, switching to list view
            /*
            for (int i = 1; i < stats.Count; i++)
            {

                richTextBox1.AppendText("Champ: " + stats[i].champName + "\n" +
                                        " Games played: " + (stats[i].sessionsPlayed + "\n" +
                                        " Games won: " + stats[i].sessionsWon + "\n" +
                                        " Games lost: " + stats[i].sessionsLost + "\n" +
                                        String.Format(" KDA: {0} - {1} - {2} \n", stats[i].championKills, stats[i].deaths, stats[i].assists)));
            }
            */
          

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemSorter sorter = listView1.ListViewItemSorter as ItemSorter;
            if (sorter == null)
            {
                sorter = new ItemSorter(e.Column);
                sorter.Order = SortOrder.Ascending;
                listView1.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }
    }
}