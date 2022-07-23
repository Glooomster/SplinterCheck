using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SplinterTools.Model;


namespace SplinterTools.Processors
{
    public class SplinterProcessor
    {

        const string ApiUrl = "https://api2.splinterlands.com";


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

        public async Task<BattlesModel> LoadBattleHiistory(string username, string format)
        {
            string result = "";
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



    }
}
