using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SplinterCheck.Processors
{
    class MessageProcessor
    {

        public class Security
        {
            public string accountSid { get; set; }
            public string authToken { get; set; }
            public string from { get; set; }
            public string to { get; set; }
        }


        public static bool CheckSecurityDetails ()
        
        {
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/Files/SecurityConfig.json"))
            {
                string json = r.ReadToEnd();
                List<Processors.MessageProcessor.Security> items = JsonConvert.DeserializeObject<List<Processors.MessageProcessor.Security>>(json);
                if (items[0].accountSid == "")
                {
                    return true;
                }

                return false;
            }
        }



        public static void SendMessage(string Message)
        {
            {


                using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/Files/SecurityConfig.json"))
                {
                    string json = r.ReadToEnd();
                    List<Security> items = JsonConvert.DeserializeObject<List<Security>>(json);

                    if (items[0].accountSid != "")
                    {
                        TwilioClient.Init(items[0].accountSid, items[0].authToken);
                        var message = MessageResource.Create(from: new Twilio.Types.PhoneNumber("whatsapp:" + items[0].from), body: Message, to: new Twilio.Types.PhoneNumber("whatsapp:" + items[0].to));
                        Console.WriteLine(message.Sid);
                    }


                }


            }
        }


    }
}
