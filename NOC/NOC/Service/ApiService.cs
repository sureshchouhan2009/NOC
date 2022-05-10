using Newtonsoft.Json;
using NOC.Models;
using NOC.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<bool> PostReplyComment(CommentReplyModel RequestModel)
        {
            bool isSuccess = false;
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer",  Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.CommentSaveing;
                var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    isSuccess = JsonConvert.DeserializeObject<bool>(result);
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;

            }
            return isSuccess;
        }
        public async Task<String> SaveCommentAttachment(MediaAttachmentModel attachmentRequestModel)
        {
            string  SuccessMessage = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SaveCommentAttachment;
                var payload = ServiceUtility.BuildRequest(attachmentRequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessMessage = JsonConvert.DeserializeObject<string>(result);
                }
            }
            catch (Exception ex)
            {
               

            }
            return SuccessMessage;
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
                    responsedata = JsonConvert.DeserializeObject<MenuItemsCountModel>(result, ServiceUtility.GetJsonSerializationSettings());
                    
                }
            }
            catch (Exception ex)
            {

            }
            return responsedata;
        }
        /// <summary>
        /// To get the detailed information of particular transaction 
        /// </summary>
        /// <param name="applicationNumber"></param>
        /// <returns></returns>
        public async Task<TransactionDetailsModel> GetTransactionDetails(string applicationNumber)
        {
            TransactionDetailsModel responsedata = new TransactionDetailsModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetTransactionDetails + applicationNumber;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<TransactionDetailsModel>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }

        /// <summary>
        /// To get list of attachments of Trasaction
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<List<AttachmentModel>> GetTransactionAttachment(string transactionID)
        {
            List<AttachmentModel> responsedata = new List<AttachmentModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetTransactionAttachment + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<AttachmentModel>>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }

        /// <summary>
        /// To get list of comments for the transaction
        /// </summary>
        /// <param name="applicationNumber"></param>
        /// <returns></returns>
        public async Task<List<CommentsModel>> GetTransactionComents(string applicationNumber)
        {
            List<CommentsModel> responsedata = new List<CommentsModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetTransactionComents + applicationNumber;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<CommentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());
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
                    responsedata = JsonConvert.DeserializeObject<List<NotificationsModel>>(result,  ServiceUtility.GetJsonSerializationSettings());
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
                    responsedata = JsonConvert.DeserializeObject<List<TransactionModel>>(result,  ServiceUtility.GetJsonSerializationSettings());
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
