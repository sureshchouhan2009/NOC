using Newtonsoft.Json;
using NOC.Models;
using NOC.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NOC.Service
{
   public class ApiService
    {
        private static ApiService _instance;
        public static ApiService Instance
        {
            get
            {
                if (_instance == null)
                
                    _instance = new ApiService();
                return _instance;
            }
        }

        public async Task<MenuItemsCountModel> GetSearchCountApiCall()
        {
             MenuItemsCountModel responsedata = new MenuItemsCountModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", await TokenClass.GetToken());
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetSearchCount;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<MenuItemsCountModel>(result);
                }
            }
            catch (Exception ex)
            {

            }
            return responsedata;
        }

        public async Task<List<NotificationsModel>> GetNotificationsList()
        {
            List<NotificationsModel> responsedata = new List<NotificationsModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", await TokenClass.GetToken());
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetNotifications;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<NotificationsModel>>(result);
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }


    }
}
