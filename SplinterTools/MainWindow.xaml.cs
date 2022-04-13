using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using System;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Windows.Controls;


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
            //LoadConfig();


            GetSplinterData();
        }

        private static List<Helpers.Accounts> LoadAccountsObject()
        {
            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";


            var customers = JsonConvert.DeserializeObject<List<Helpers.Accounts>>(File.ReadAllText(json));


            return customers;
        }




        public async void GetSplinterData()
        {



            var accountDetails = LoadAccountsObject();
            List<Helpers.User> NewList = new List<Helpers.User>();

            for (int i = 0; i < accountDetails.Count; i++)
            {
                var SplinterInfo = await SplinterProcessor.LoadSplinterInformation(accountDetails[i].accName);
                var QuestInfo = await SplinterProcessor.LoadQuestInformation(accountDetails[i].accName);
                var RentalInfo = await SplinterProcessor.LoadRentalInformation(accountDetails[i].accName);



                string questItems, leagueTest, warningMessage;


                if (SplinterInfo.league == 4)
                    leagueTest = "Silver III";
                else if (SplinterInfo.league == 5)
                    leagueTest = "Silver II";
                else if (SplinterInfo.league == 6)
                    leagueTest = "Silver I";
                else if (SplinterInfo.league == 7)
                    leagueTest = "Gold III";
                else if (SplinterInfo.league == 8)
                    leagueTest = "Gold I";
                else if (SplinterInfo.league == 9)
                    leagueTest = "Gold I";
                else leagueTest = "Warning";


                if (SplinterInfo.collection_power < accountDetails[i].power)
                {
                    warningMessage = "Power Missing";
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



                NewList.Add(new Helpers.User()
                {
                    RentCancel = rentCancelNumber,
                    Name = SplinterInfo.name,
                    Rating = SplinterInfo.rating,
                    CollectionPower = SplinterInfo.collection_power,
                    league = leagueTest,
                    completed_items = questItems,
                    created_date = QuestInfo[0].created_date,
                    claim_date = QuestInfo[0].claim_date,
                    reward_qty = QuestInfo[0].reward_qty,
                    warning = warningMessage,

                });
            }

            SplinterList.ItemsSource = NewList;

        }

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }


        public void SetTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();

        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetSplinterData();
        }


        private void btnAutoStop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }


        private void btnTestButton_Click(object sender, RoutedEventArgs e)
        {
            TestWindow win2 = new TestWindow();
            win2.Show();
        }
    }
}
