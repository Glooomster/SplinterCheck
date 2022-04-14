using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;



namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string fileOfReportInXML = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSplinterData();
        }




        List<ListViewItem> UserModelList = new List<ListViewItem>();


        public async void GetSplinterData()
        {


            var accountDetails = Processors.LoadAccountDetailsProcessor.LoadAccountsObject();




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



                questItems = QuestInfo[0].completed_items.ToString() + " / " + QuestInfo[0].total_items.ToString();

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
                    CollectionPower = SplinterInfo.collection_power,
                    League = leagueTest,
                    Completed_items = questItems,
                    Created_date = QuestInfo[0].created_date,
                    Claim_date = QuestInfo[0].claim_date,
                    Reward_qty = QuestInfo[0].reward_qty,
                    Warning = warningMessage,

                };
                UserModelList.Add(OneListItem);


            }

            SplinterList.ItemsSource = UserModelList;

        }

        public DispatcherTimer dispatcherTimer = new();


        //public void ChangeRowColor()
        //{
        //    UserModelList[0].Background = NewBackground;
        //    listView.Items.Refresh();
        //}


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
            GetSplinterData();
        }


        private void BtnAutoStop_Click(object sender, RoutedEventArgs e)
        {
            BtnRefresh.IsEnabled = true;
            dispatcherTimer.Stop();
        }


        private void BtnTestButton_Click_1(object sender, RoutedEventArgs e)
        {
            TestWindow win2 = new();
            win2.Show();
        }



    }
}
