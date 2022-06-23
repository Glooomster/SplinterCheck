using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;



namespace SplinterTools.Processors
{
    public class AccountDetailsProcessor
    {
        public static List<Model.AccountModel> LoadAccountsObject()
        {



            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
            var SplinterAccounts = JsonConvert.DeserializeObject<List<Model.AccountModel>>(File.ReadAllText(json));

            return SplinterAccounts;


        }

        public static void updateAccounts(string account, int power)

        {

            string json = Directory.GetCurrentDirectory() + "/Files/AppConfig.json";
            var jsonData = System.IO.File.ReadAllText(json);

            var SplinterAccounts = JsonConvert.DeserializeObject<List<Model.AccountModel>>(jsonData);

            SplinterAccounts.Add(new Model.AccountModel()

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
