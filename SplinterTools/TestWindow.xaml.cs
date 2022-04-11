using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Newtonsoft.Json;
using SplinterTools.Helpers;

namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {


        public string fileOfReportInXML = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";

        //public string ConfigFile = Directory.GetCurrentDirectory() + "/Files/AppConfig.xml";
        public string[] strArray = XDocument.Load(Directory.GetCurrentDirectory() + "/Files/AppConfig.xml").Descendants("accName")
            .Select(element => element.Value).ToArray();

        public string[] strArray3 = XDocument.Load(Directory.GetCurrentDirectory() + "/Files/AppConfig.xml").Descendants("accName")
            .Select(element => element.Value).ToArray();


        XDocument doc = XDocument.Load(Directory.GetCurrentDirectory() + "/Files/AppConfig.xml");

        public TestWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }



        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadConfig();
            GetSplinterData();

        }

        private static List<Accounts> LoadAccountsObject()
        {
            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";


            var customers = JsonConvert.DeserializeObject<List<Helpers.Accounts>>(File.ReadAllText(json));


            return customers;
        }
        public async void GetSplinterData()
        {



            var accountDetails = LoadAccountsObject();
            if (accountDetails != null)
            {
                for (int i = 0; i < accountDetails.Count; i++)
                {
                    System.Diagnostics.Debug.Print(accountDetails[i].accName + "test" + accountDetails[i].power);
                }
            }



            List<Helpers.User> NewList = new List<Helpers.User>();

            for (int i = 0; i < accountDetails.Count; i++)
            {
                var SplinterInfo = await SplinterProcessor.LoadSplinterInformation(accountDetails[i].accName);
                var QuestInfo = await SplinterProcessor.LoadQuestInformation(accountDetails[i].accName);

                string questItems = "";
                string leagueTest = "";
                string warningMessage = "";

                if (SplinterInfo.league == 4)
                    leagueTest = "S III";
                else if (SplinterInfo.league == 6)
                    leagueTest = "S I";


                if (SplinterInfo.collection_power < accountDetails[i].power)
                {
                    warningMessage = "Power Missing";
                }


                questItems = QuestInfo[0].completed_items.ToString() + " / " + QuestInfo[0].total_items.ToString();



                NewList.Add(new Helpers.User()
                {
                    Name = SplinterInfo.name,
                    Rating = SplinterInfo.rating,
                    CollectionPower = SplinterInfo.collection_power,
                    league = leagueTest,
                    completed_items = questItems,
                    created_date = QuestInfo[0].created_date,
                    claim_date = QuestInfo[0].claim_date,
                    reward_qty = QuestInfo[0].reward_qty,
                    warning = warningMessage
                });
            }

            SplinterList.ItemsSource = NewList;

        }

    }
}
