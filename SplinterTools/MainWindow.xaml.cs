
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;



namespace SplinterTools
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string fileOfReportInXML = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";

        public string warningMessageTotal = "";
        public string sentWhatsUpMessage = "";

        public DispatcherTimer dispatcherTimer = new();
        public int TestValue;

        public Boolean enableWhatsup = false;




        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Helpers.SplinterData.splinterlandsSetting = Task.Run(() => new Processors.Splinterlands().GetSplinterlandsSetting()).Result;
            GetSplinterData(0);
        }

        List<ListViewItem> UserModelList = new List<ListViewItem>();



        public async void GetSplinterData(int testr)
        {



            var accountDetails = Processors.AccountDetailsProcessor.LoadAccountsObject();


            UserModelList.Clear();




            for (int i = 0; i < accountDetails.Count; i++)
            {

                ListViewItem OneListItem = new ListViewItem();

                string warningMessage = "";

                var SplinterInfo = await Processors.SplinterProcessor.LoadSplinterInformation(accountDetails[i].AccName);
                var QuestInfo = await Processors.SplinterProcessor.LoadQuestInformation(accountDetails[i].AccName);
                var RentalInfo = await Processors.SplinterProcessor.LoadRentalInformation(accountDetails[i].AccName);


                int baseRshares = Helpers.SplinterData.splinterlandsSetting.loot_chests.quest[QuestInfo[0].chest_tier].@base;
                double multiplier = Helpers.SplinterData.splinterlandsSetting.loot_chests.quest[QuestInfo[0].chest_tier].step_multiplier;
                int chests = 0;
                int fp_limit = baseRshares;


                while (QuestInfo[0].rshares > fp_limit)
                {
                    chests++;
                    fp_limit = Convert.ToInt32(baseRshares + fp_limit * multiplier);
                }



                string leagueWildName = Helpers.SplinterData.splinterlandsSetting.leagues.modern[SplinterInfo.league].name;
                string leagueModernName = Helpers.SplinterData.splinterlandsSetting.leagues.modern[SplinterInfo.modern_league].name;
                string splinter = Helpers.SplinterData.splinterlandsSetting.daily_quests.Where(x => x.active == true && x.name == QuestInfo[0].name).FirstOrDefault().data.value;
                string questItems = QuestInfo[0].completed_items.ToString();




                //Last 50 Matches Win rate modern


                Helpers.SplinterData.battles = Task.Run(() => new Processors.Splinterlands().GetRateSetting(accountDetails[i].AccName, "modern")).Result;

                int totalmodernWins = 0;
                int totalmoderngames = Helpers.SplinterData.battles.battles.Length;
                

                if (Helpers.SplinterData.battles != null)
                {
                    for (int it = 0; it < totalmoderngames; it++)
                    {
                        if (Helpers.SplinterData.battles.battles[it].winner == accountDetails[i].AccName)
                        {
                            totalmodernWins++;
                        }
                    }
                }


                //Last 50 Matches Win rate wild


                Helpers.SplinterData.battles = Task.Run(() => new Processors.Splinterlands().GetRateSetting(accountDetails[i].AccName, "wild")).Result;

                int totalWildnWins = 0;
                int totalWildgames = Helpers.SplinterData.battles.battles.Length;


                if (Helpers.SplinterData.battles != null)
                {
                    for (int it = 0; it < totalWildgames; it++)
                    {
                        if (Helpers.SplinterData.battles.battles[it].winner == accountDetails[i].AccName)
                        {
                            totalWildnWins++;
                        }
                    }
                }



                //rental check
                int rentCancelNumber = 0;

                if (RentalInfo != null)
                {
                    for (int it = 0; it < RentalInfo.Length; it++)
                    {
                        if (RentalInfo[it].cancel_date != null)
                        {
                            //System.Diagnostics.Debug.Print(RentalInfo[it].cancel_date.ToString());
                            //System.Diagnostics.Debug.Print(it.ToString());
                            rentCancelNumber++;
                        }
                    }
                }




                if (SplinterInfo.collection_power < accountDetails[i].Power)
                {


                    warningMessage = "Power Missing: " + (accountDetails[i].Power - SplinterInfo.collection_power).ToString() + "\n";
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



                OneListItem.Content = new Helpers.UserModel()
                {
                    RentCancel = rentCancelNumber,
                    Name = SplinterInfo.name,
                    RatingModern = SplinterInfo.modern_rating,
                    LeagueModern = leagueModernName,
                    ModernWinRate = (SplinterInfo.modern_wins * 100.00 / SplinterInfo.modern_battles).ToString("#") + "%",
                    ModernLast50 = (totalmodernWins * 100.00 / totalmoderngames).ToString("#") + "%",
                    RatingWild = SplinterInfo.rating,
                    LeagueWild = leagueWildName,
                    WildWinRate = (SplinterInfo.wins * 100.00 / SplinterInfo.battles).ToString("#") + "%",
                    WildLast50 = (totalWildnWins * 100.00 / totalWildgames).ToString("#") + "%",
                    Capture_rate = SplinterInfo.capture_rate / 100,
                    CollectionPower = SplinterInfo.collection_power,

                    QuestTitle = splinter,
                    Completed_items = questItems,
                    Earned_Chests = chests,
                    Rshares = QuestInfo[0].rshares,
                    Created_date = QuestInfo[0].created_date,
                    Reward_qty = QuestInfo[0].reward_qty,
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
            var user = row.Content as Helpers.UserModel;
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
            var user = row.Content as Helpers.UserModel;
            moreInformation.ShowAccount(user);
        }

        private void MoreInformation_NextAccount(MoreInfo moreInformation)
        {
            if (SplinterList.SelectedIndex + 1 < SplinterList.Items.Count) SplinterList.SelectedIndex += 1;
            var row = SplinterList.SelectedItem as ListViewItem;
            var user = row.Content as Helpers.UserModel;
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
