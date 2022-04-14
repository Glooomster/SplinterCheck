using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;



namespace SplinterTools.Processors
{
    public class LoadAccountDetailsProcessor
    {
        public static List<Helpers.AccountModel> LoadAccountsObject()
        {
            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
            var SplinterAccounts = JsonConvert.DeserializeObject<List<Helpers.AccountModel>>(File.ReadAllText(json));

            return SplinterAccounts;
        }

    }
}
