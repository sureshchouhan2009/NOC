using Newtonsoft.Json;
using NOC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NOC.Utility
{
    public class TokenClass
    {
        public static async Task<string> GetToken()
        {
            string token = null;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://portal.gpceast.com/er/noc/");
                                                                                       
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
                nvc.Add(new KeyValuePair<string, string>("password", "user123"));
                nvc.Add(new KeyValuePair<string, string>("username", "applicant_test"));
                var req = new HttpRequestMessage(HttpMethod.Post, "https://portal.gpceast.com/er/noc/Token") 
                { Content = new FormUrlEncodedContent(nvc) };

                var res = await client.SendAsync(req);
                if (res.IsSuccessStatusCode)
                {
                    string result = await res.Content.ReadAsStringAsync();
                    var userData = JsonConvert.DeserializeObject<TokenModel>(result);
                    token = userData.access_token;
                }
            }
            catch (Exception ex)
            {

            }
            return token;
        }

    }
}
