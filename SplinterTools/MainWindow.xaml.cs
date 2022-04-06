using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using System;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string[] strArray = new string[]
        //            {
        //        "glooomy",
        //        "gloomynator",
        //        "gloomster" };

        //public string ConfigFile = Directory.GetCurrentDirectory() + "/Files/AppConfig.xml";
        public string[] strArray = XDocument.Load(Directory.GetCurrentDirectory() + "/Files/AppConfig.xml").Descendants("user")
            .Select(element => element.Value).ToArray();


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();


        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GetSplinterData();
        }


        public async void GetSplinterData()
        {
            List<Helpers.User> NewList = new List<Helpers.User>();
            foreach (string str in strArray)
            {
                var SplinterInfo = await SplinterProcessor.LoadSplinterInformation(str);
                var QuestInfo = await SplinterProcessor.LoadQuestInformation(str);

                NewList.Add(new Helpers.User()
                {
                    Name = SplinterInfo.name,
                    Rating = SplinterInfo.rating,
                    CollectionPower = SplinterInfo.collection_power,
                    league = SplinterInfo.league,
                    total_items = QuestInfo[0].total_items,
                    completed_items = QuestInfo[0].completed_items,
                    created_date = QuestInfo[0].created_date,
                    claim_date = QuestInfo[0].claim_date,
                    reward_qty = QuestInfo[0].reward_qty
                });
            }

            SplinterList.ItemsSource = NewList;

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

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
    }
}
