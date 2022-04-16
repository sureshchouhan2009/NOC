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
        /// <summary>
        /// To Get the No of application/Transaction count available in menu options
        /// </summary>
        /// <returns></returns>
        public async Task<MenuItemsCountModel> GetSearchCountApiCall()
        {
             MenuItemsCountModel responsedata = new MenuItemsCountModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
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
        /// <summary>
        /// to get list of Notifications after clicking on menu page Items
        /// </summary>
        /// <param name="filterID"></param>
        /// <returns></returns>
        public async Task<List<NotificationsModel>> GetNotificationsList()
        {
            List<NotificationsModel> responsedata = new List<NotificationsModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
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

       

        /// <summary>
        /// to get list of trnsactions /application after clicking on menu page Items
        /// </summary>
        /// <param name="filterID"></param>
        /// <returns></returns>

        public async Task<List<TransactionModel>> ApplicantGetTransactionList(int filterID)
        {
            List<TransactionModel> responsedata = new List<TransactionModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.applicantGetTransactionList+filterID.ToString();
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<TransactionModel>>(result);
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }
        /// <summary>
        /// Need Pass here Token and URL and it returns the True/False
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="RequestUrl"></param>
        /// <returns></returns>
        public async Task<bool> ValidateUserTypeFromToken(String Token, String RequestUrl)
        {
            bool responseData = false;
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    responseData = true;
                }
               
            }
            catch (Exception ex)
            {

            }
            return responseData;
        }
    }
}
