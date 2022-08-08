
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
using SplinterLands.DTOs.Models;

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








            //var RentalInfo = await Processors.SplinterProcessor.LoadBattleHistory222(UserModel.Name, "modern");



            SpDataHelper.battlesClass = Task.Run(() => new Processors.SplinterProcessor().LoadBattleHistory(UserModel.Name, "modern")).Result;


            List<Testdata> list = new List<Testdata>();



            foreach (var test in listgrouped)
            {
        
                dataGridMatches.Items.Add(new Testdata(){
                    Value1 = test.Card_Detail_Id2,
                    Value2 = test.Count

                });
                

                //list.Add(new Testdata { Value1 = test.winner, Value2 = test.ruleset, Value3 = test.format });

      
            }
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

        public List<testdata3> listgrouped = new List<testdata3>();


        public class testdata
        {
            public long Card_Detail_Id { get; set; }
        }

        public class testdata3
        {
            public long Card_Detail_Id2 { get; set; }
            public int Count { get; set; }
        }

        private void GetBattlesGrouped(string username)
        {
            var test = (dynamic)null;



            var client = new RestClient("https://api2.splinterlands.com/battle/history?player=" + username);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<SplinterLands.DTOs.Models.PlayerBattles>(response.Content);



            List<testdata> list = new List<testdata>();
  


            foreach (var item in data.Battles)

            {


                if (item.Player_1 == username)

                {
                    test = item.BattleDetails.Team1.Monsters;
                }
                else;
                {
                    test = item.BattleDetails.Team2.Monsters;
                }

                foreach (var item2 in test)
                {
                    list.Add(new testdata { Card_Detail_Id = item2.Card_Detail_Id });
                }


            }

            var grouped = list.GroupBy(x => x.Card_Detail_Id);
            foreach (var group in grouped)
            {

                listgrouped.Add(new testdata3 { Card_Detail_Id2 = group.Key, Count = group.Count() });
            }

            listgrouped = listgrouped.OrderByDescending(x => x.Count).ToList();   




        }


        private void GetConnection(string username)
        {


            var client = new RestClient("https://api2.splinterlands.com/battle/history?player=" + username);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<SplinterLands.DTOs.Models.PlayerBattles>(response.Content);

        }

        //public PlayerBattles GetBattlesForPlayer(string playerName)
        //{
 
        //        //return GetClientResponse<PlayerBattles>($"battle/history?player={playerName}", false);

        //}


    }


}
