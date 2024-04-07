using Newtonsoft.Json;
using NOC.Models;
using NOC.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NOC.Utility
{
    public class TokenClass
    {

        //dont need after MSAL

        //public static async Task<string> GetToken(string UserName, String Password)
        //{
        //    string token = null;
        //    try
        //    {
        //        var client = new HttpClient();
        //        client.BaseAddress = new Uri(Urls.TokenBaseUrl);

        //        var nvc = new List<KeyValuePair<string, string>>();
        //        //nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
        //        //nvc.Add(new KeyValuePair<string, string>("password", "user123"));
        //        //nvc.Add(new KeyValuePair<string, string>("username", "applicant_test"));


        //        nvc.Add(new KeyValuePair<string, string>("grant_type", "password"));
        //        nvc.Add(new KeyValuePair<string, string>("password", Password));
        //        nvc.Add(new KeyValuePair<string, string>("username", UserName));
        //        var req = new HttpRequestMessage(HttpMethod.Post, Urls.TokenURL) 
        //        { Content = new FormUrlEncodedContent(nvc) };

        //        var res = await client.SendAsync(req);
        //        if (res.IsSuccessStatusCode)
        //        {
        //            string result = await res.Content.ReadAsStringAsync();
        //            var userData = JsonConvert.DeserializeObject<TokenModel>(result);
        //            token = userData.access_token;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return token;
        //}



        public static async Task<string> GetTokenDetails(string Token)
        {
            string userID = "";
                try
                {
                    var client = ServiceUtility.CreateNewHttpClient();
                    var authHeader = new AuthenticationHeaderValue("bearer", Token);
                    client.DefaultRequestHeaders.Authorization = authHeader;
                    String RequestUrl = Urls.Gettokenurls ;
                    var response = await client.GetAsync(RequestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        userID = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                       
                    }
                }
                catch (Exception ex)
                {


                }
                return userID;
            }

        public static async Task<string> PostApiCallForUserID(string Token)
        {
            string result = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                string cookiesValue = "MobileToken=" + Token + ";Ismobile=true";
                client.DefaultRequestHeaders.Add("Cookie", cookiesValue);
                var req = new HttpRequestMessage(HttpMethod.Post, Urls.GetUserIDFromToken) { Content = { } };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                   var resultJson = await response.Content.ReadAsStringAsync();
                   result=   JsonConvert.DeserializeObject<string>(resultJson, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static async Task<UserAuthorizationModel> GetTokenAzureTokenDetails(string Token)
        {
            UserAuthorizationModel userAuthorizationModel = new UserAuthorizationModel();
            try
            {
             string cookiesValue= "MobileToken=" + Token+ ";Ismobile=true";
                var client = ServiceUtility.CreateNewHttpClient();
                client.DefaultRequestHeaders.Add("Cookie", cookiesValue);
                String RequestUrl = Urls.checkAuthorieduser; ;
                var payload = ServiceUtility.BuildRequest(new AzureClassTest { StringOne="" });
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    userAuthorizationModel = JsonConvert.DeserializeObject<UserAuthorizationModel>(result);
                }
                else
                {
                    string result = await response.Content.ReadAsStringAsync();
                    userAuthorizationModel = JsonConvert.DeserializeObject<UserAuthorizationModel>(result);
                }
            }
            catch (Exception ex)
            {
                userAuthorizationModel = new UserAuthorizationModel();

            }
            return userAuthorizationModel;
        }


       

    }
}

public class AzureClassTest
{
    public string StringOne { get; set; }
}
