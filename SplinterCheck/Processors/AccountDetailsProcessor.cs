using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using SplinterCheck.Library.Models;

namespace SplinterCheck.Processors
{
    public class AccountDetailsProcessor
    {
        public static List<AccountModel> LoadAccountsObject()
        {

            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
            var SplinterAccounts = JsonConvert.DeserializeObject<List<AccountModel>>(File.ReadAllText(json));

            return SplinterAccounts;
        }

        public static void updateAccounts(string account, int power)

        {

            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
            var jsonData = System.IO.File.ReadAllText(json);

            var SplinterAccounts = JsonConvert.DeserializeObject<List<AccountModel>>(jsonData);

            SplinterAccounts.Add(new AccountModel()

            {
                AccName = account,
                Power = power
            }
            );

            jsonData = JsonConvert.SerializeObject(SplinterAccounts);
            System.IO.File.WriteAllText(json, jsonData);
        }
    }
}
