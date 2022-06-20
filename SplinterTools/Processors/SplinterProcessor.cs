﻿using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace SplinterTools.Processors
{
    public class SplinterProcessor
    {

        public static async Task<SplinterModel> LoadSplinterInformation(string Name)
        {


            string url = "https://game-api.splinterlands.com/players/details?name=" + Name;

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


            string url = "https://game-api.splinterlands.com/players/quests?username=" + Name;

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


            string url = "https://api2.splinterlands.com/market/active_rentals?renter=" + Name + "&offset=0&limit=5000";

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
    }
}
