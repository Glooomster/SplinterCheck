
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using SplinterCheck.Library.Models;
using SplinterCheck.Helpers;
using SplinterCheck.Processors;
using RestSharp;
using System.Diagnostics;

namespace SplinterCheck
{


    public partial class MainWindow : Window
    {
        public string fileOfReportInXML = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
        public string warningMessageTotal = "";
        public string sentWhatsUpMessage = "";
        public DispatcherTimer dispatcherTimer = new();
        public int TestValue;
        public Boolean enableWhatsup = false;

        public List<ListViewItem> UserModelList = new List<ListViewItem>();


        public MainWindow()
        {
            //TestClass();

            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool checkSecurity = Processors.MessageProcessor.CheckSecurityDetails();

            if (checkSecurity)
            {
                BtnEnableWhatsUp.IsEnabled = false;
            };


            Helpers.SpDataHelper.splinterlandsSetting = Task.Run(() => new SplinterProcessor().LoadSplinterlandsSetting()).Result;
            GetSplinterData(0);
        }


        public async void GetSplinterData(int testr)
        {

            var accountDetails = Processors.AccountDetailsProcessor.LoadAccountsObject();

            UserModelList.Clear();


            //for (int i = 0; i < accountDetails.Count; i++)
            foreach (var account in accountDetails)

            {

                ListViewItem OneListItem = new ListViewItem();

                string warningMessage = "";

                var SplinterInfo = await SplinterProcessor.LoadSplinterInformation(account.AccName);
                var QuestInfo = await SplinterProcessor.LoadQuestInformation(account.AccName);
                var RentalInfo = await SplinterProcessor.LoadRentalInformation(account.AccName);
                var ballance = await SplinterProcessor.LoadBalances(account.AccName);


                int baseRshares = Helpers.SpDataHelper.splinterlandsSetting.loot_chests.quest[QuestInfo[0].chest_tier].@base;
                double multiplier = Helpers.SpDataHelper.splinterlandsSetting.loot_chests.quest[QuestInfo[0].chest_tier].step_multiplier;
                int chests = 0;
                int fp_limit = baseRshares;


                while (QuestInfo[0].rshares > fp_limit)
                {
                    chests++;
                    fp_limit = Convert.ToInt32(baseRshares + fp_limit * multiplier);
                }

                string leagueWildName = SpDataHelper.splinterlandsSetting.leagues.modern[SplinterInfo.league].name;
                string leagueModernName = SpDataHelper.splinterlandsSetting.leagues.modern[SplinterInfo.modern_league].name;
                string splinter = SpDataHelper.splinterlandsSetting.daily_quests.Where(x => x.active == true && x.name == QuestInfo[0].name).FirstOrDefault().data.value;
                string questItems = QuestInfo[0].completed_items.ToString();






                //Last 50 Matches Win rate modern


                Debug.WriteLine("Start" + DateTime.Now.ToString());

                string getModernBattles = ApiRequest.GetApiResponse("battle/history?player=" + account.AccName + "&format=modern" );

                

                var modernBattles = JsonConvert.DeserializeObject<PlayerBattles>(getModernBattles);


                Debug.WriteLine("start second" + DateTime.Now.ToString());

                 SpDataHelper.playerBattles = Task.Run(() => new SplinterProcessor().LoadBattleHistory(account.AccName, "modern")).Result;


                Debug.WriteLine("done" + DateTime.Now.ToString());

                int totalmodernWins = 0;
                int totalmoderngames = modernBattles.Battles.Count;
                double modernDec = 0;


                if (modernBattles != null)
                {

                    foreach (var battleItem in modernBattles.Battles)
                    {
                        if (battleItem.BattleDetails.Winner == account.AccName)
                        {
                            totalmodernWins++;
                            modernDec = modernDec + Convert.ToDouble(battleItem.Reward_Sps);

                        }

                    }
                }

                //Last 50 Matches Win rate wild
                string getWildBattles = ApiRequest.GetApiResponse("battle/history?player=" + account.AccName + "&format=wild");

                var wildBattles = JsonConvert.DeserializeObject<PlayerBattles>(getWildBattles);




                //Helpers.SpDataHelper.battlesClass = Task.Run(() => new Processors.SplinterProcessor().LoadBattleHistory(account.AccName, "wild")).Result;

                int totalWildnWins = 0;
                int totalWildgames = wildBattles.Battles.Count;
                double wildDec = 0;

                if (wildBattles != null)
                {

                    foreach (var battleItem in wildBattles.Battles)
                    {
                        if (battleItem.BattleDetails.Winner == account.AccName)
                        {
                            totalWildnWins++;
                            wildDec = wildDec + Convert.ToDouble(battleItem.Reward_Sps);

                        }

                    }
                }

                //rental check
                int rentCancelNumber = 0;

                if (RentalInfo != null)
                {
                    foreach(var rentalItem in RentalInfo)
                    //for (int it = 0; it < RentalInfo.Length; it++)
                    {
                        if (rentalItem.cancel_date != null)
                        {
                            rentCancelNumber++;
                        }
                    }
                }

                // get potions


                string goldPotions = "";
                string legendaryPotions = "";

                if (ballance != null)
                {
                    foreach(var ballanceItem in ballance)

                    //for (int it = 0; it < ballance.Length; it++)
                    {
                        if (ballanceItem.token == "GOLD")
                        {
                            goldPotions = ballanceItem.balance.ToString();
                        }
                        if (ballanceItem.token == "LEGENDARY")
                        {
                            legendaryPotions = ballanceItem.balance.ToString();
                        }
                    }
                }
   



                // warnings

                if (SplinterInfo.collection_power < account.Power)
                {


                    warningMessage = "Power Missing: " + (account.Power - SplinterInfo.collection_power).ToString() + "\n";
                    //OneListItem.Background = Brushes.Coral;

                }

                if (QuestInfo[0].created_date < DateTime.UtcNow.AddHours(-24))
                {
                    warningMessage = warningMessage + "Last Quest: \n" + QuestInfo[0].created_date + "\n"; // (DateTime.UtcNow.AddHours(-2) - QuestInfo[0].created_date).Hours.ToString() + "\n";
                    //OneListItem.Background = Brushes.Coral;
                }

                if (rentCancelNumber > 0)
                {
                    warningMessage = warningMessage + "Cancelations: " + rentCancelNumber.ToString() + "\n";
                    //OneListItem.Background = Brushes.Coral;
                }
                //else warningMessage = " N/A ";


                if (warningMessage.Length > 0)
                {
                    warningMessageTotal = warningMessageTotal + SplinterInfo.name + ":\n" + warningMessage + "\n";
                }




                // Quests


                OneListItem.Content = new UserModel()
                {
                    RentCancel = rentCancelNumber,
                    Name = SplinterInfo.name,
                    RatingModern = SplinterInfo.modern_rating,
                    LeagueModern = leagueModernName,
                    ModernWinRate = (SplinterInfo.modern_wins * 100.00 / SplinterInfo.modern_battles).ToString("#") + "%",
                    ModernLast50 = (totalmodernWins * 100.00 / totalmoderngames).ToString("#") + "%",
                    ModernLast50Dec = Math.Round(modernDec, 2),
                    RatingWild = SplinterInfo.rating,
                    LeagueWild = leagueWildName,
                    WildWinRate = (SplinterInfo.wins * 100.00 / SplinterInfo.battles).ToString("#") + "%",
                    WildLast50 = (totalWildnWins * 100.00 / totalWildgames).ToString("#") + "%",
                    WildLast50Dec = Math.Round(wildDec, 2),
                    Capture_rate = SplinterInfo.capture_rate / 100,
                    CollectionPower = SplinterInfo.collection_power,
                    QuestTitle = splinter,
                    Completed_items = questItems,
                    Earned_Chests = chests,
                    Rshares = QuestInfo[0].rshares,
                    Created_date = QuestInfo[0].created_date,
                    Reward_qty = QuestInfo[0].reward_qty,
                    Potions = goldPotions + " / " + legendaryPotions,

                    //Warning = warningMessage,
                    //Test = +testr,

                };

                UserModelList.Add(OneListItem);

            }

            if (warningMessageTotal.Length > 0)
            {


                if (warningMessageTotal != sentWhatsUpMessage)
                {
                    //MessageBox.Show(warningMessageTotal.ToString());
                    if (enableWhatsup)
                    {
                        Processors.MessageProcessor.SendMessage(warningMessageTotal);
                    }

                    sentWhatsUpMessage = warningMessageTotal;

                }

                //clear the message
                warningMessageTotal = "";
            }

            SplinterList.ItemsSource = UserModelList;
            SplinterList.Items.Refresh();

        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            sentWhatsUpMessage = "";


            int timerTicker = Processors.RefreshProcessor.GetTimerSeconds(cmbRefresh.SelectedIndex);

            //int timerTicker = GetTimerSeconds(cmbRefresh.SelectedIndex);


            if (dispatcherTimer != null)
            {
                dispatcherTimer.Tick += DispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, timerTicker);
                dispatcherTimer.Start();

            }

            BtnRefresh.IsEnabled = false;
            cmbRefresh.IsEnabled = false;

        }

        protected void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TestValue += 1;

            GetSplinterData(TestValue);
        }

        private void BtnAutoStop_Click(object sender, RoutedEventArgs e)
        {
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Tick -= DispatcherTimer_Tick;
                dispatcherTimer.Stop();

            }

            BtnRefresh.IsEnabled = true;
            cmbRefresh.IsEnabled = true;

        }


        private void BtnTestButton_Click(object sender, RoutedEventArgs e)
        {

            //         SplinterLandsClient client = new SplinterLandsClient();
            //         var balances = client.GetTokenBalancesForPlayer("gloomster");
        }

        private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            var row = sender as ListViewItem;
            var user = row.Content as UserModel;
            var moreInformation = new MoreInfo();
            moreInformation.PrevAccount += MoreInformation_PrevAccount;
            moreInformation.NextAccount += MoreInformation_NextAccount;



            moreInformation.Owner = this;
            moreInformation.ShowAccount(user);


            //MessageBox.Show($"test {user.Name}");
        }

        private void MoreInformation_PrevAccount(MoreInfo moreInformation)
        {
            if (SplinterList.SelectedIndex > 0) SplinterList.SelectedIndex -= 1;
            var row = SplinterList.SelectedItem as ListViewItem;
            var user = row.Content as UserModel;
            moreInformation.ShowAccount(user);
        }

        private void MoreInformation_NextAccount(MoreInfo moreInformation)
        {
            if (SplinterList.SelectedIndex + 1 < SplinterList.Items.Count) SplinterList.SelectedIndex += 1;
            var row = SplinterList.SelectedItem as ListViewItem;
            var user = row.Content as UserModel;
            moreInformation.ShowAccount(user);
        }

        private void BtnAddACcount_Click(object sender, RoutedEventArgs e)
        {
            var addNewAccount = new AddAccount();


            addNewAccount.SaveData += SaveData_AddAccount;



            addNewAccount.Owner = this;
            addNewAccount.ShowAddWindow();


        }


        private void SaveData_AddAccount(AddAccount addNewAccount)
        {


            GetSplinterData(0);
        }

        private void BtnEnableWhatsUp_Click(object sender, RoutedEventArgs e)
        {
            if (enableWhatsup)
            {
                enableWhatsup = false;
            }
            else
            {
                enableWhatsup = true;
            }

        }



    }
}
