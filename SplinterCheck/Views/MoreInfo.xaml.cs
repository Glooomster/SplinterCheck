
using System;
using System.Collections.Generic;
using System.Windows;
using SplinterCheck.Library.Models;
using SplinterCheck.Helpers;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

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

            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }

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

            //var RentalInfo = await Processors.SplinterProcessor.LoadBattleHistory222(UserModel.Name, "modern");



            SpDataHelper.battlesClass = Task.Run(() => new Processors.SplinterProcessor().LoadBattleHistory(UserModel.Name, "modern")).Result;


            List<Testdata> list = new List<Testdata>();



            foreach (var test in SpDataHelper.battlesClass.battles)
            {
        
                dataGridMatches.Items.Add(new Testdata(){
                    Value1 = test.winner,
                    Value2 = test.ruleset,
                    Value3 = test.format
                });
                

                list.Add(new Testdata { Value1 = test.winner, Value2 = test.ruleset, Value3 = test.format });

      
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
    }


}
