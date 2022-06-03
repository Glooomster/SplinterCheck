using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using SplinterTools.Helpers;

namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string fileOfReportInXML = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";





        public int TestValue;


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSplinterData(0);
        }

        List<ListViewItem> UserModelList = new List<ListViewItem>();




        public async void GetSplinterData(int testr)
        {

           // var LeagueInfo = await Processors.SplinterProcessor.LoadLeagueInformation();

            var accountDetails = Processors.LoadAccountDetailsProcessor.LoadAccountsObject();

            UserModelList.Clear();


            List<DailyLootModel> authors = new List<DailyLootModel>
{
                    new DailyLootModel { Base = 300,Step = 1.2, Level = 1 },
                    new DailyLootModel { Base = 5000, Step = 1.13, Level = 2},
                    new DailyLootModel { Base = 18000, Step = 1.09, Level = 3 }
};

            foreach (DailyLootModel author in authors)
            {
                MessageBox.Show($"Author: {author.Base}:{author.Step}:{author.Level}");
            }



            for (int i = 0; i < accountDetails.Count; i++)
            {

                ListViewItem OneListItem = new ListViewItem();



                var SplinterInfo = await Processors.SplinterProcessor.LoadSplinterInformation(accountDetails[i].AccName);
                var QuestInfo = await Processors.SplinterProcessor.LoadQuestInformation(accountDetails[i].AccName);
                var RentalInfo = await Processors.SplinterProcessor.LoadRentalInformation(accountDetails[i].AccName);



                string questItems, leagueTest, warningMessage;


                int value = SplinterInfo.league;
                var enumDisplayStatus = (Helpers.Settings.League)value;
                leagueTest = enumDisplayStatus.ToString();


                if (SplinterInfo.collection_power < accountDetails[i].Power)
                {
                    warningMessage = "Power Missing";
                    OneListItem.Background = Brushes.Coral;
                    //Processors.MessageProcessor.SendMessage(warningMessage);
                }
                else warningMessage = " N/A ";



                questItems = QuestInfo[0].completed_items.ToString(); //+ " / " + QuestInfo[0].reward_qty.ToString();

                int rentCancelNumber = 0;

                if (RentalInfo != null)
                {
                    for (int it = 0; it < RentalInfo.Length; it++)
                    {
                        if (RentalInfo[it].cancel_date != null)
                        {
                            System.Diagnostics.Debug.Print(RentalInfo[it].cancel_date.ToString());
                            System.Diagnostics.Debug.Print(it.ToString());
                            rentCancelNumber++;
                        }
                    }


                }
                OneListItem.Content = new Helpers.UserModel()
                {
                    RentCancel = rentCancelNumber,
                    Name = SplinterInfo.name,
                    Rating = SplinterInfo.rating,
                    Capture_rate = SplinterInfo.capture_rate/100,
                    CollectionPower = SplinterInfo.collection_power,
                    League = leagueTest,
                    Completed_items = questItems,
                    Rshares = QuestInfo[0].rshares,
                    Created_date = QuestInfo[0].created_date,
                    Claim_date = QuestInfo[0].claim_date,
                    Reward_qty = QuestInfo[0].reward_qty,
                    Warning = warningMessage,
                    Test =+ testr,



                };
                UserModelList.Add(OneListItem);

            }

            SplinterList.ItemsSource = UserModelList;
            SplinterList.Items.Refresh();

        }




        public DispatcherTimer dispatcherTimer = new();



        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            
            BtnRefresh.IsEnabled = false;
            SetTimer();
        }


        public void SetTimer()
        {
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();

        }

        protected void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TestValue += 1; 

            GetSplinterData(TestValue);
        }


        private void BtnAutoStop_Click(object sender, RoutedEventArgs e)
        {
            BtnRefresh.IsEnabled = true;
            dispatcherTimer.Stop();
        }


        private void BtnTestButton_Click_1(object sender, RoutedEventArgs e)
        {
            MoreInfo win2 = new();
            win2.Show();
        }

        private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            var row = sender as  ListViewItem;
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
            if (SplinterList.SelectedIndex > 0 ) SplinterList.SelectedIndex -= 1;
            var row = SplinterList.SelectedItem as ListViewItem;
            var user = row.Content as Helpers.UserModel;
            moreInformation.ShowAccount(user);
        }

        private void MoreInformation_NextAccount(MoreInfo moreInformation)
        {
            if (SplinterList.SelectedIndex+1 < SplinterList.Items.Count) SplinterList.SelectedIndex += 1;
            var row = SplinterList.SelectedItem as ListViewItem;
            var user = row.Content as Helpers.UserModel;
            moreInformation.ShowAccount(user);
        }
    }
}
