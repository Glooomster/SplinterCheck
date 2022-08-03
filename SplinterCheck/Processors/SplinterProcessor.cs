using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SplinterCheck.Library.Models;


namespace SplinterCheck.Processors
{
    public class SplinterProcessor
    {
        

        const string ApiUrl = "https://api2.splinterlands.com";
        private readonly string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";



        private async Task<T> GetClientResponseAsync<T>(string endPoint) where T : new()
        {

            var client = new RestClient(ApiUrl);
            client.UserAgent = UserAgent;

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            var response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content) ?? new T();


        }
        //public async Task<SplinterlandsSetting> LoadSplinterlandsSetting()
        //{
            
        //    var set = new SplinterlandsSetting()
        //    {
        //        SplinterlandsSetting = await GetClientResponseAsync<Bat_Event_List<
        //    }
        //    string result = "";
        //    HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiUrl + "/settings");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsStringAsync();
        //    }
        //    return JsonConvert.DeserializeObject<SplinterlandsSetting>(result);
        //}

        public async Task<SplinterlandsSetting> LoadSplinterlandsSetting()
        {
            string result = "";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiUrl + "/settings");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<SplinterlandsSetting>(result);
        }

        public static async Task<SplinterModel> LoadSplinterInformation(string Name)
        {


            string url = ApiUrl + "/players/details?name=" + Name;

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                SplinterModel result = await response.Content.ReadAsAsync<SplinterModel>();

                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public static async Task<QuestModel[]> LoadQuestInformation(string Name)
        {


            string url = ApiUrl + "/players/quests?username=" + Name;

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            {
                if (response.IsSuccessStatusCode)
                {
                    QuestModel[] result = await response.Content.ReadAsAsync<QuestModel[]>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static async Task<RentalModel[]> LoadRentalInformation(string Name)
        {

            string url = ApiUrl + "/market/active_rentals?renter=" + Name + "&offset=0&limit=5000";

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            {
                if (response.IsSuccessStatusCode)
                {
                    RentalModel[] result = await response.Content.ReadAsAsync<RentalModel[]>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<BattlesModel> LoadBattleHistory(string username, string format)
        {
            string result;
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiUrl + "/battle/history?player=" + username + "&format=" + format);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            return JsonConvert.DeserializeObject<BattlesModel>(result);
        }


        public static async Task<BalanceModel[]> LoadBalances(string Name)
        {

            string url = ApiUrl + "/players/balances?username=" + Name;

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            {
                if (response.IsSuccessStatusCode)
                {
                    BalanceModel[] result = await response.Content.ReadAsAsync<BalanceModel[]>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }



    }
}
