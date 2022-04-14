using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SplinterTools.Processors
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




        public static void SendMessage(string Message)
        {
            {


                using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/Files/SecurityConfig.json"))
                {
                    string json = r.ReadToEnd();
                    List<Security> items = JsonConvert.DeserializeObject<List<Security>>(json);

                    TwilioClient.Init(items[0].accountSid, items[0].authToken);
                    var message = MessageResource.Create(from: new Twilio.Types.PhoneNumber("whatsapp:" + items[0].from), body: Message, to: new Twilio.Types.PhoneNumber("whatsapp:" + items[0].to));
                    Console.WriteLine(message.Sid);
                }


            }
        }


    }
}
