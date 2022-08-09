using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace SplinterCheck.Helpers
{
    public class ApiRequest
    {

        public static string GetApiResponse(string api)
        {
            string baseApi = "https://api2.splinterlands.com/";

            var client = new RestClient(baseApi + api );
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            //var data = JsonConvert.DeserializeObject<SplinterLands.DTOs.Models.PlayerBattles>(getModernBattles)

            return response.Content;

        }


        public async Task<T> GetApiResponse2<T>(string api) where T : new()
        {
            string baseApi = "https://api2.splinterlands.com/";

            var client = new RestClient(baseApi + api);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            //var data = JsonConvert.DeserializeObject<PlayerBattles>(response.Content) ?? new T();

            return JsonConvert.DeserializeObject<T>(response.Content) ?? new T();

            //return response.Content;

        }

    }


}
