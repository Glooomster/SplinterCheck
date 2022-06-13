using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SplinterTools.Model;
using SplinterTools.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SplinterTools.Processors
{
    public class Splinterlands
    {


        const string API_URL = "https://api2.splinterlands.com";
        const string SP_USER_DATA = "/players/details?name=";
        const string SP_QUEST_DATA = "/players/quests?username=";
        const string SP_CARDS_COLLECTION = "/cards/collection/@@_username_@@?v=@@_timestamp_@@&token=@@_accessToken_@@&username=@@_username_@@";
        const string SP_OUTSTANGING_MATCH = "/players/outstanding_match?username=";
        const string SP_AIRDROP_DATA = "/players/sps?v=1638714545572&token=@@_accessToken_@@&username=@@_username_@@";
        const string SP_PlAYER_BALANCE = "/players/balances?username=";
        const string SP_CLAIM_SEASON_REWARDS = "/players/login?name=@@_username_@@&ref=&browser_id=@@_browserid_@@&session_id=@@_sessionid_@@&sig=@@_signature_@@&ts=@@_timestamp_@@";
        const string SP_TRANSACTION_DETAILS = "/transactions/lookup?trx_id=";
        const string SP_MATCH_DETAILS = "/battle/status?id=";
        const string SP_MATCH_ENEMY_PICK = "/players/outstanding_match?username=";
        const string SP_MATCH_RESULTS = "/battle/history2?player=";
        const string SP_ACCESS_TOKEN = "/players/login?name=@@_username_@@&ref=&browser_id=@@_bid_@@&session_id=@@_sid_@@&sig=@@_signature_@@&ts=@@_timestamp_@@";
        const string SP_SPLINTERLANDS_CARDS = "/cards/get_details";
        const string SP_SPLINTERLANDS_SETTINGS = "/settings";

        public async Task<SplinterlandsSettings> GetSplinterlandsSettings()
        {
            string result = "";
            HttpResponseMessage response = await HttpWebRequest.client.GetAsync(API_URL + SP_SPLINTERLANDS_SETTINGS);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<SplinterlandsSettings>(result);
        }





        public async Task<string> GetUserAccesToken(string username, string bid, string sid, string signature, string ts)
        {
            string result = "";
            HttpResponseMessage response = await HttpWebRequest.client.GetAsync(API_URL + SP_ACCESS_TOKEN.Replace("@@_username_@@", username).Replace("@@_bid_@@", bid).Replace("@@_sid_@@", sid).Replace("@@_signature_@@", signature).Replace("@@_timestamp_@@", ts));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        public async Task<string> GetOutstandingMatch(string username)
        {
            string result = "";

            HttpResponseMessage response = await HttpWebRequest.client.GetAsync(API_URL + SP_OUTSTANGING_MATCH + username);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
        public async Task<string> GetTransactionDetails(string tx)
        {
            string result = "";

            HttpResponseMessage response = await HttpWebRequest.client.GetAsync(API_URL + SP_TRANSACTION_DETAILS + tx);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
        public async Task<string> GetSeasonDetails(string username, string bid, string sid, string sig, string ts)
        {
            string result = "";
            HttpResponseMessage response = await HttpWebRequest.client.GetAsync(API_URL + SP_CLAIM_SEASON_REWARDS.Replace("@@_username_@@", username).Replace("@@_browserid_@@", bid).Replace("@@_sessionid_@@", sid).Replace("@@_signature_@@", sig).Replace("@@_timestamp_@@", ts));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}