﻿using Newtonsoft.Json;
using NOC.Enums;
using NOC.Models;
using NOC.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NOC.Models.ReviwerSpecific;

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


        //for mobile this method saves actual file to the server folder structure and returns the file path
        public async Task<String> SaveCommentAttachment(NewAttachmentModel attachmentRequestModel)
        {
            string  SuccessMessage = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.UploadAttachmentToServer;
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

        // this method actually saves the file path to the DB
        public async Task<String> SaveCommentAttachmentToDB(MediaAttachmentModel RequestModel)
        {
            string SuccessMessage = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SaveAttachmentToDatabase;
                var payload = ServiceUtility.BuildRequest(RequestModel);
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
                String RequestUrl = CheckAndReturnUserSpecificUrlForSearchCount(true);
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

        private string CheckAndReturnUserSpecificUrlForSearchCount(bool IsSearchCountFlow)
        {
            if (IsSearchCountFlow)
            {
                if (Session.Instance.CurrentUserType == UserTypes.Officer)
                {
                    return Urls.GetSearchCountOfficer;
                }
                else if (Session.Instance.CurrentUserType == UserTypes.Reviewer)
                {
                    return Urls.GetSearchCountReviewer;
                }
                else if (Session.Instance.CurrentUserType == UserTypes.Stackholder)
                {
                    return Urls.GetSearchCountStackHolder;
                }
                else
                {
                    return Urls.GetSearchCountApplicant;
                }
            }
            else
            {
                if (Session.Instance.CurrentUserType == UserTypes.Officer)
                {
                    return Urls.OfficerGetTransactionList;
                }
                else if (Session.Instance.CurrentUserType == UserTypes.Reviewer)
                {
                    return Urls.reviewerGetTransactionList;
                }
                else if (Session.Instance.CurrentUserType == UserTypes.Stackholder)
                {
                    return Urls.stakeholderTransactionList;
                }
                else
                {
                    return Urls.applicantGetTransactionList;
                }
            }


            
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
                String RequestUrl = Urls.GetTransactionDetailsNew + applicationNumber;
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
        /// GetCommentsRelatedAttachment for reviewer Page
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<List<CommentsRelatedAttachmentModel>> GetCommentsRelatedAttachment(string transactionID)
        {
            List<CommentsRelatedAttachmentModel> responsedata = new List<CommentsRelatedAttachmentModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetCommentsRelatedAttachment + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<CommentsRelatedAttachmentModel>>(result, ServiceUtility.GetJsonSerializationSettings());
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
                    var commentList= JsonConvert.DeserializeObject<List<CommentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());

                    responsedata = ModifyCommentListAndReturnAsCommentAndRepliedCommentsList(commentList);


                    //responsedata = JsonConvert.DeserializeObject<List<CommentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }

        public async Task<string> SaveNewCommentFromReviewer(PostCommentModel saveCommentModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostDecisionCommentsave;
                var payload = ServiceUtility.BuildRequest(saveCommentModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<String>(result);
                }
            }
            catch (Exception ex)
            {
                SuccessResult = ex.ToString();
            }
            return SuccessResult;
        }


        public async Task<string> UpdateExisitingCommentFromReviewer(UpdateExisitingCommentModel updateCommentModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostDecisionCommentUpdate;
                var payload = ServiceUtility.BuildRequest(updateCommentModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<String>(result);
                }
            }
            catch (Exception ex)
            {
                SuccessResult = ex.ToString();
            }
            return SuccessResult;
        }





        private List<CommentsModel> ModifyCommentListAndReturnAsCommentAndRepliedCommentsList(List<CommentsModel> commentList)
        {
            // List<CommentsModel> modifiedList = new List<CommentsModel>();
            foreach (var com in commentList)
            {
                if (com.Comments.ParentCommentID == null)
                {
                    foreach (var sub in commentList)
                    {
                        if (com.Comments.CommentsID == sub.Comments.ParentCommentID)
                        {
                            com.list.Add(com.Comments.Comment);
                        }
                    }
                }
                



            }
            var list= commentList.Where(x => x.Comments.ParentCommentID == null).ToList();
            return list;
        }

        public async Task<bool> UploadFileAgainstReviewerComment(ReviewerAttachmentUploadModel uploadModel)
        {
            bool SuccessResult = false;
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SaveStakeholderResponseAttachment;
                var payload = ServiceUtility.BuildRequest(uploadModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<bool>(result);
                }
            }
            catch (Exception ex)
            {
               
            }
            return SuccessResult;
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
                String RequestUrl = CheckAndReturnUserSpecificUrlForSearchCount(false)+filterID.ToString();
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



        ///

        public async Task<String> PostNoObjection(ObjectionOptionPostModel NoObjectionRequestModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostNoObjection;
                var payload = ServiceUtility.BuildRequest(NoObjectionRequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                //if (response?.IsSuccessStatusCode ?? false)
                //{
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<String>(result);
               // }
            }
            catch (Exception ex)
            {
                SuccessResult = ex.ToString();


            }
            return SuccessResult;
        }

        public async Task<String> PostObjection(ObjectionOptionPostModel RaiseObjectionRequestModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostNoObjection;
                var payload = ServiceUtility.BuildRequest(RaiseObjectionRequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                //if (response?.IsSuccessStatusCode ?? false)
                //{
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<String>(result);
                //}
            }
            catch (Exception ex)
            {
                SuccessResult = ex.ToString();

            }
            return SuccessResult;
        }


        public async Task<String> PostOwnNoc(ObjectionOptionPostModel requestModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostOwnNocs;
                var payload = ServiceUtility.BuildRequest(requestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                //if (response?.IsSuccessStatusCode ?? false)
                //{
                string result = await response.Content.ReadAsStringAsync();
                SuccessResult = JsonConvert.DeserializeObject<String>(result);
                //}
            }
            catch (Exception ex)
            {
                SuccessResult = ex.ToString();

            }
            return SuccessResult;
        }

        public async Task<String> GetTransferNocApiCall(ObjectionOptionPostModel requestModel)
        {
            string responsedata = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.TransferOwnership + "?" + "transNumber=" + requestModel.transactionid + "&" + "transferUserId=" + requestModel.userID;

                //


                //

                var response = await client.GetAsync(RequestUrl);
                //if (response.IsSuccessStatusCode)
                //{
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                //}
            }
            catch (Exception ex)
            {

                responsedata = ex.ToString();
            }
            return responsedata;
        }




        public async Task<List<StackholderModel>> GetStackHolderList(string transactionID)
        {
            List<StackholderModel> responsedata = new List<StackholderModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetStackholderList + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<StackholderModel>>(result, ServiceUtility.GetJsonSerializationSettings());
                    //responsedata.Add(responsedata.LastOrDefault());
                    //responsedata.Add(responsedata.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }


        public async Task<List<AllStackholderResponse>> GetAllStackHolderResponseData(string transactionID)
        {
            List<AllStackholderResponse> responsedata = new List<AllStackholderResponse>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetAllStackholderResponsedata + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<AllStackholderResponse>>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }
        /// <summary>
        /// GetStackholderRelatedAttachment for reviewer Page
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<List<StackholderAttachmentsModel>> GetStackholderRelatedAttachment(string transactionID)
        {
            List<StackholderAttachmentsModel> responsedata = new List<StackholderAttachmentsModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetStackholderRelatedAttachment + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<StackholderAttachmentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }



        /// <summary>
        /// specific comment which reviewer given already
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<ReviewerSpecificCommentModel> GetReviewerSpecificComment(string transactionID)
        {
            ReviewerSpecificCommentModel responsedata = new ReviewerSpecificCommentModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetStackholderRelatedAttachment + transactionID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<ReviewerSpecificCommentModel>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }
    }
}
