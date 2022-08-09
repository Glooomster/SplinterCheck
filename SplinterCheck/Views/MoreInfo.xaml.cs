
using System;
using System.Collections.Generic;
using System.Windows;
using SplinterCheck.Library.Models;
using SplinterCheck.Helpers;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using RestSharp;
using System.Linq;

namespace SplinterCheck
{
    /// <summary>
    /// Interaction logic for MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : Window
    {
        public event Action<MoreInfo> NextAccount;

        public event Action<MoreInfo> PrevAccount;

        const string ApiUrl = "https://api2.splinterlands.com";



        public class Testdata {

            public long Value1 { get; set; }
            public int Value2 { get; set; }
            //public string Value3 { get; set; }

        }



        public MoreInfo()
        {
            InitializeComponent();

            // create test value
            //instatiate a new test object 


            // add details 


        }

        public UserModel UserModel { get; set; }

        public async void ShowAccount(UserModel user)
        {
            UserModel = user;
            lblAccountName.Content = $"{UserModel.Name}";



            GetBattlesGrouped(user.Name);



           // SpDataHelper.battlesClass = Task.Run(() => new Processors.SplinterProcessor().LoadBattleHistory(UserModel.Name, "modern")).Result;


           // List<Testdata> list = new List<Testdata>();



            //foreach (var loadCards in mostPlayedMonsterList)
            //{
        
            //    dataGridMatches.Items.Add(new FilteredMonsters(){
            //        Card_Detail_Id = loadCards.Card_Detail_Id,
            //        Count = loadCards.Count

            //    });
                

            //    list.Add(new Testdata { Value1 = test.winner, Value2 = test.ruleset, Value3 = test.format });

      
            //}
            //dataGridMatches.Items.Add(list);


            //int test = Helpers.SpDataHelper.battles.battles.Length;
            Show();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            PrevAccount.Invoke(this);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NextAccount.Invoke(this);
        }

        public List<FilteredMonsters> mostPlayedMonsterList = new List<FilteredMonsters>();


        public class FilteredMonsters

        {
            public long Card_Detail_Id { get; set; }
            public string Card_Name { get; set; }
            public int Count { get; set; }
            public string Name { get; set; }
        }

        //public class testdata3
        //{
        //    public long Card_Detail_Id2 { get; set; }
        //    public int Count { get; set; }
        //}

        private void GetBattlesGrouped(string username)
        {
            var monsterVariable = (dynamic)null; 
            //List<BattleCard> monsters = new List<BattleCard>();
            List<FilteredMonsters> monstersList = new List<FilteredMonsters>();


            string getApiBattles = ApiRequest.GetApiResponse("battle/history?player=" + username);



            //string getCardDetails = GetApiCall("cards/get_details", "");
            //var cards = JsonConvert.DeserializeObject<SplinterCheck.Models.Card>(getCardDetails);

            if (getApiBattles != null)
            {

                var data = JsonConvert.DeserializeObject<PlayerBattles>(getApiBattles);






                foreach (var battlesPlayed in data.Battles)

                {

                    if (battlesPlayed.BattleDetails.Team1 != null & battlesPlayed.BattleDetails.Team2 != null)
                    {
                        if (battlesPlayed.Player_1 == username)

                        {
                            monsterVariable = battlesPlayed.BattleDetails.Team1.Monsters;
                        }
                        else;
                        {
                            monsterVariable = battlesPlayed.BattleDetails.Team2.Monsters;
                        }


                    }




                    foreach (var filteredList in monsterVariable)
                    {
                        monstersList.Add(new FilteredMonsters { Card_Detail_Id = filteredList.Card_Detail_Id });
                    }
                }




                var groupedMonsters = monstersList.GroupBy(x => x.Card_Detail_Id);
                foreach (var group in groupedMonsters)
                {

                    //mostPlayedMonsterList.Add(new FilteredMonsters { Card_Detail_Id = group.Key, Count = group.Count() });






                    dataGridMatches.Items.Add(new FilteredMonsters()
                    {
                        Card_Detail_Id = group.Key,
                        Name = "",
                        Count = group.Count()
                    });

                }

            }
           




            //mostPlayedMonsterList = mostPlayedMonsterList.OrderByDescending(x => x.Count).ToList();

            //foreach (var loadCards in mostPlayedMonsterList)
            //{

            //    dataGridMatches.Items.Add(new FilteredMonsters()
            //    {
            //        Card_Detail_Id = loadCards.Card_Detail_Id,
            //        Count = loadCards.Count

            //    });


            //list.Add(new Testdata { Value1 = test.winner, Value2 = test.ruleset, Value3 = test.format });


            //}


        }


        //public string GetApiCall(string api,string username) 
        //{
        //    string baseApi = "https://api2.splinterlands.com/";

        //    var client = new RestClient(baseApi + api + username);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = client.Execute(request);

        //    return response.Content;

        //}

        //public PlayerBattles GetBattlesForPlayer(string playerName)
        //{
 
        //        //return GetClientResponse<PlayerBattles>($"battle/history?player={playerName}", false);

        //}


    }


}
