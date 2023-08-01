using Newtonsoft.Json;
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
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using NOC.Interfaces;
using System.Diagnostics;
using Xamarin.CommunityToolkit.Extensions;
using Newtonsoft.Json.Linq;

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
        /// To Get the attchment type available for DD
        /// </summary>
        /// <returns></returns>
        public async Task<List<AttachmentsTypesResourceModel>> GetAttachmentsTypesForDD()
        {
            List<AttachmentsTypesResourceModel> responsedata = new List<AttachmentsTypesResourceModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetAttachmentsTypesForDD;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<AttachmentsTypesResourceModel>>(result, ServiceUtility.GetJsonSerializationSettings());

                }
            }
            catch (Exception ex)
            {

            }
            return responsedata.Where(e=>e.Isvisible==true).ToList();
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


        public async Task<bool> deleteReviewerSpecificCustomCondition(string commentID)
        {
            bool isSuccess = false;
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer",  Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.deleteReviewerSpecificCustomConditions+ commentID;
                //var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = null };
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

        private string CheckAndReturnUserSpecificUrlForSearchCount(bool IsSearchCountFlow, int filterID=0)
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
                    if (filterID == 17)//for inprogress application and officer user
                    {
                        return Urls.InProgressOfficerGetTransactionList;
                    }
                    else
                    {
                        return Urls.OfficerGetTransactionList;
                    }
                    
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
        /// To get the detailed information of particular transaction 
        /// </summary>
        /// <param name="applicationNumber"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetailsOldOne(string applicationNumber)
        {
            Transaction responsedata = new Transaction();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetTransactionDetails + applicationNumber;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                  var  result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<TrasactionDetailsOld>(result, ServiceUtility.GetJsonSerializationSettings()).Transaction;

                   
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
        public async Task<List<CommentsRelatedAttachmentModel>> GetCommentsRelatedAttachment(string TransactionID,string StackHolderOrReviewerSolutionRoleID, bool IsStackholder)
        {
            List<CommentsRelatedAttachmentModel> responsedata = new List<CommentsRelatedAttachmentModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetCommentsRelatedAttachment + TransactionID+"/"+ StackHolderOrReviewerSolutionRoleID+"/"+ IsStackholder;
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
                String RequestUrl = "";
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;

                RequestUrl = Session.Instance.CurrentUserType == UserTypes.Applicant?Urls.GetTransactionComents + applicationNumber: Urls.GetTransactionCommentsForProcessor + applicationNumber;


               // RequestUrl = Urls.GetTransactionCommentsForProcessor + applicationNumber;// for processor specific
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var commentList= JsonConvert.DeserializeObject<List<CommentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());

                   

                    List<AttachmentModel> allAttachments =  await GetTransactionAttachment(Session.Instance.CurrentTransaction.Transaction.TransactionID.ToString());
                    responsedata = ModifyCommentListAndReturnAsCommentAndRepliedCommentsList(commentList, allAttachments);

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





        private List<CommentsModel> ModifyCommentListAndReturnAsCommentAndRepliedCommentsList(List<CommentsModel> commentList, List<AttachmentModel> allAttachments)
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
                            com.list.Add(sub.Comments.Comment);
                        }
                    }
                }
            }
            var list= commentList.Where(x => x.Comments.ParentCommentID == null).ToList();
            List<CommentsModel> commentWithAttachment = new List<CommentsModel>();
            foreach (var modifiedcomment in list)
            {
                foreach(var attachment in allAttachments)
                {
                    if(modifiedcomment.Comments.CommentsID== attachment.CommentsID)
                    {
                        modifiedcomment.Attachments.Add( attachment);
                    }
                }
                if(Session.Instance.IsCompletedApplicationFlow || Session.Instance.IsNewNocApplicationFlow|| Session.Instance.CurrentUserType != UserTypes.Applicant)
                {
                    
                        modifiedcomment.IsApplicatUser = false;
                    
                }
                else
                {
                    if (modifiedcomment.list.Count > 0)
                    {
                        modifiedcomment.IsApplicatUser = false;
                    }
                    else
                    {
                        modifiedcomment.IsApplicatUser = true;
                    }
                }
               
                commentWithAttachment.Add(modifiedcomment);
            }
            return commentWithAttachment;
        }

        public async Task<string> UploadFileAgainstReviewerComment(ReviewerAttachmentUploadModel uploadModel)
        {
            string SuccessResult = "";
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
                    SuccessResult = JsonConvert.DeserializeObject<string>(result);
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
                    responsedata = JsonConvert.DeserializeObject<List<NotificationsModel>>(result,  ServiceUtility.GetJsonSerializationSettings()).OrderByDescending(x=>x.CreationDate).ToList();
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
                String RequestUrl = CheckAndReturnUserSpecificUrlForSearchCount(false,filterID)+filterID.ToString();
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
                    string result = await response.Content.ReadAsStringAsync();

                    UserRolesModel role = JsonConvert.DeserializeObject<UserRolesModel>(result, ServiceUtility.GetJsonSerializationSettings());
                    if (role.roles != "")
                    {
                        responseData = true;
                    }
                    else
                    {
                        responseData = false;
                    }

                }
               
            }
            catch (Exception ex)
            {
                responseData = false;
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

        public async Task<String> PostObjection(ObjectionOptionPostModel RaiseObjectionRequestModel)
        {
            String SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.PostObjectionRaised;
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


        public async Task<String> PostOwnNoc(OwnNocPostModel requestModel)
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

        public async Task<String> PostTransferNocApiCall(TransferNocRequestModel TransferRequestModel)
        {
            string responsedata = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.TransferOwnership;

                var payload = ServiceUtility.BuildRequest(TransferRequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
                else
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
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
        //public async Task<List<StackholderAttachmentsModel>> GetStackholderRelatedAttachment(string transactionID)
        //{
        //    List<StackholderAttachmentsModel> responsedata = new List<StackholderAttachmentsModel>();
        //    try
        //    {
        //        var client = ServiceUtility.CreateNewHttpClient();
        //        var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
        //        client.DefaultRequestHeaders.Authorization = authHeader;
        //        String RequestUrl = Urls.GetStackholderRelatedAttachment + transactionID;
        //        var response = await client.GetAsync(RequestUrl);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string result = await response.Content.ReadAsStringAsync();
        //            responsedata = JsonConvert.DeserializeObject<List<StackholderAttachmentsModel>>(result, ServiceUtility.GetJsonSerializationSettings());
        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //    return responsedata;
        //}

        /// <summary>
        /// This Method Retrives Stackholder related condtion list to Display in Condtion Tab
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<List<StackholderConditionInReviewerPageModel>> StackHolderCommentsForCondition(string transactionID)
        {
            List<StackholderConditionInReviewerPageModel> responsedata = new List<StackholderConditionInReviewerPageModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SpecificConditionGetAllStakeHolderResponse+transactionID;
                //var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = null };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<StackholderConditionInReviewerPageModel>>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }


        /// <summary>
        /// This Method Retrives Reviewer related condtion list to Display in Condtion Tab
        /// </summary>
        /// <param name="Application Number"></param>
        /// <returns></returns>
        public async Task<List<SystemAndUserSpCondition>> GetReviewerConditons(string ApplicationNumber)
        {
            List<SystemAndUserSpCondition>responsedata = new List<SystemAndUserSpCondition>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.GetReviewerConditons + ApplicationNumber;
                //var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = null };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var compositCondition = JsonConvert.DeserializeObject<ReviewerConditionInReviewerPageModel>(result, ServiceUtility.GetJsonSerializationSettings());

                    List<SystemAndUserSpCondition> systemAndUserSpCondition = new List<SystemAndUserSpCondition>();
                    int index = 1;
                   
                        foreach(var systemCondition in compositCondition.SystemSpCondition)
                        {

                            responsedata.Add(new SystemAndUserSpCondition
                            {
                                IndexNumber = index++,
                                COMMENTTYPE = systemCondition.COMMENTTYPE,
                                CONDITIONS = systemCondition.CONDITIONS,
                                CreatedBy = systemCondition.CreatedBy,
                                CreationDate = systemCondition.CreationDate,
                                LastModificationDate = systemCondition.LastModificationDate,
                                SOLUTIONROLEID = systemCondition.SOLUTIONROLEID,
                                STAKEHOLDERID = systemCondition.STAKEHOLDERID,
                                TRANSACTIONID = systemCondition.TRANSACTIONID,
                                TRA_SPECCOND_ID = systemCondition.TRA_SPECCOND_ID,
                                USERID = systemCondition.USERID,
                            });
                        }

                        foreach (var userCondition in compositCondition.UserSpCondition)
                        {
                            responsedata.Add(new SystemAndUserSpCondition
                            {
                                IndexNumber = index++,
                                COMMENTTYPE = userCondition.COMMENTTYPE,
                                CONDITIONS = userCondition.CONDITIONS,
                                CreatedBy = userCondition.CreatedBy,
                                CreationDate = userCondition.CreationDate,
                                LastModificationDate = userCondition.LastModificationDate,
                                SOLUTIONROLEID = userCondition.SOLUTIONROLEID,
                                STAKEHOLDERID = userCondition.STAKEHOLDERID,
                                TRANSACTIONID = userCondition.TRANSACTIONID,
                                TRA_SPECCOND_ID = userCondition.TRA_SPECCOND_ID,
                                USERID = userCondition.USERID,
                            });
                        }
                    }
                
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }

        internal async Task<String> PostreviewerSpecificComment(PostReviewerSpecificComment usaveCondition)
        {
            string responsedata = "";
            try
            {
                bool IsReviewer = Session.Instance.CurrentUserType == UserTypes.Reviewer;
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SaveSpecificCondition+ IsReviewer.ToString().ToLower()+"/"+ usaveCondition.TRANSACTIONID;
                var payload = ServiceUtility.BuildRequest(usaveCondition);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
                else
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {


            }
            return responsedata;
        }
        /// <summary>
        /// Update the Existing 
        /// </summary>
        /// <param name="specificComment"></param>
        /// <returns></returns>
        internal async Task<String> UpdateReviewerSpecificComment(UpdateReviewerSpecificComment updatedCondition)
        {
            string responsedata = "";
            try
            {
                bool IsReviewer = Session.Instance.CurrentUserType == UserTypes.Reviewer;
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.UpdatepecificCondition ;
                var payload = ServiceUtility.BuildRequest(updatedCondition);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
                else
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
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
                String RequestUrl = Urls.GetReviewerSpecificComment + transactionID;
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





        public async Task<List<EligibletranferNocsUserModel>> GeteleigibleTransferNocsUsersList()
        {
            List<EligibletranferNocsUserModel> responsedata = new List<EligibletranferNocsUserModel>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.transferOwnerUserList;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responsedata = JsonConvert.DeserializeObject<List<EligibletranferNocsUserModel>>(result, ServiceUtility.GetJsonSerializationSettings());

                }
            }
            catch (Exception ex)
            {

            }
            return responsedata;
        }



        public async Task<string> SaveNewCommentCommonforApplicantAndInternal(SaveNewCommentFromApplicantModel SaveNewCommentModel)
        {
            string SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.SaveApplicatNewComment;// save url is same for internal and applicant
                var payload = ServiceUtility.BuildRequest(SaveNewCommentModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<string>(result);
                }
            }
            catch (Exception ex)
            {

            }
            return SuccessResult;
        }

        public async Task<string> SubmitNewCommentCommonforApplicantOnly(SubmitApplicantCommentsModel SubmitNewCommentModel)
        {
            string SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = "";
                if (Session.Instance.CurrentUserType == UserTypes.Applicant)
                {
                    RequestUrl = Urls.SubmitCommentsForApplicant;
                }
                else
                {
                    RequestUrl = Urls.SubmitCommentsForProcessor;
                }

               // String RequestUrl = Urls.SubmitCommentsForApplicant;// save url is same for internal and applicant
                var payload = ServiceUtility.BuildRequest(SubmitNewCommentModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<string>(result);
                }
            }
            catch (Exception ex)
            {

            }
            return SuccessResult;
        }

        //Phase II
        public async Task<bool> ChangeReadStatusForNotifications(int TransactionID)
        {
            bool SuccessResult = false;
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.ChangeIsReadStatusForNotifications;
                var payload = ServiceUtility.BuildRequest(new List<int> { TransactionID });
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<bool>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return SuccessResult;
        }

        public async Task<string> DownloadTransactionDetailsAsPDF(string TransactionNumber)
        {
            string SuccessResult = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.downloadPdfURL + TransactionNumber;//17 digit
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { };
                var response = await client.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<string>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return SuccessResult;
        }




        public async Task<StackholderUserCheckModel> checkStackholderdetails1(string TransactionID, string userID, string WorkFlow)
        {
            StackholderUserCheckModel stackholderResponse1 = new StackholderUserCheckModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.checkStatckholder1+WorkFlow+ "?tranid=" + TransactionID + "&Userid="+ userID;
               // String RequestUrl = Urls.checkStatckholder1 + "15811" + "&Userid=" + "02c4dcb1-fdee-485b-80da-327b3e313f2";

                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    stackholderResponse1 = JsonConvert.DeserializeObject<StackholderUserCheckModel>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return stackholderResponse1;
        }

        public async Task<StackholderTypeCheckModel> checkStackholderdetails2( string userID)
        {
            StackholderTypeCheckModel stackholderResponse2 = new StackholderTypeCheckModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.checkStatckholder2+ userID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    stackholderResponse2 = JsonConvert.DeserializeObject<StackholderTypeCheckModel>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return stackholderResponse2;
        }

        /// <summary>
        /// Get Stackholder Response Page Data{response Tab } 
        /// </summary>
        /// <param name="TransactionNumber"></param>
        /// <returns></returns>
        public async Task<StackholderResponsePageAttachmentModel> GetStackholderResponsePageData(string SthcmntID)
        {
            StackholderResponsePageAttachmentModel SuccessResult = new StackholderResponsePageAttachmentModel();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.getStackholderResponsepageData + SthcmntID;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    SuccessResult = JsonConvert.DeserializeObject<StackholderResponsePageAttachmentModel>(result, ServiceUtility.GetJsonSerializationSettings());
                }
            }
            catch (Exception ex)
            {
            }
            return SuccessResult;
        }


        public async Task<List<StackHolderAndOfficerSpecifcConditions>> GetStackholderResponseCondition(string transactionID, string workFlow)
        {
            List<StackHolderAndOfficerSpecifcConditions> responseData = new List<StackHolderAndOfficerSpecifcConditions>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.getStackholderResponsepageConditions + transactionID + "/" + workFlow;
                //var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = null };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responseData = JsonConvert.DeserializeObject<List<StackHolderAndOfficerSpecifcConditions>>(result);
                }
                var client1 = ServiceUtility.CreateNewHttpClient();
                var authHeader1 = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client1.DefaultRequestHeaders.Authorization = authHeader1;
                String RequestUrl1 = Urls.getStackholderResponsepageConditionsAsLoggedInPersons  + workFlow;
                var trasaction = await GetTransactionDetailsOldOne(Session.Instance.CurrentTransaction.Transaction.TransactionNumber);
                var payload = ServiceUtility.BuildRequest(trasaction);
                var req1 = new HttpRequestMessage(HttpMethod.Post, RequestUrl1) { Content = payload };
                var response1 = await client1.SendAsync(req1);
                if (response1?.IsSuccessStatusCode ?? false)
                {
                    string result = await response1.Content.ReadAsStringAsync();
                    var OldCommentModelList = JsonConvert.DeserializeObject<ReviewerConditionInReviewerPageModel>(result);
                    int index = 1;
                    foreach (var CItem in OldCommentModelList.UserSpCondition)
                    {
                        responseData.Add(new StackHolderAndOfficerSpecifcConditions
                        {
                           
                            IndexNumber = index++,
                            CommentType = CItem.COMMENTTYPE,
                            condition = CItem.CONDITIONS,
                            TRA_SPECCOND_ID = CItem.TRA_SPECCOND_ID,
                        }
                        ) ;
                    }
                    
                }

            }
            catch (Exception ex)
            {
               

            }
            return responseData;
        }


         public async Task<List<StackHolderAndOfficerSpecifcConditions>> GetOffficerResponseCondition(string transactionID)
        {
            List<StackHolderAndOfficerSpecifcConditions> responseData = new List<StackHolderAndOfficerSpecifcConditions>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                String RequestUrl = Urls.getOfficerResponsepageConditions + transactionID + "/" + "officerreviewer";
                //var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = null };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responseData = JsonConvert.DeserializeObject<List<StackHolderAndOfficerSpecifcConditions>>(result);
                }
            }
            catch (Exception ex)
            {
               

            }
            return responseData;
        }

       

        public async Task<string> GenericGetApiCall(String RequestUrl)
        {
            string result = "";
            try
            {
                
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                var response = await client.GetAsync(RequestUrl);
                if (response.IsSuccessStatusCode)
                {
                     result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<string> GenericPostApiCall(string RequestUrl,object RequestModel=null)
        {
            string Result = "";
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                
                var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    Result = await response.Content.ReadAsStringAsync();
                    
                }
            }
            catch (Exception ex)
            {
                

            }
            return Result;
        }

        public async Task<List<StackHolderAndOfficerSpecifcConditions>> GetReviewerConditions(string transactionID)
        {
            List<StackHolderAndOfficerSpecifcConditions> Result = new List<StackHolderAndOfficerSpecifcConditions>();
            try
            {
                var client = ServiceUtility.CreateNewHttpClient();
                var authHeader = new AuthenticationHeaderValue("bearer", Session.Instance.Token);
                client.DefaultRequestHeaders.Authorization = authHeader;
                string RequestUrl = Urls.getOfficerResponsepageConditions + transactionID + "/" + "reviewer";//15837
                object RequestModel = null;
                var payload = ServiceUtility.BuildRequest(RequestModel);
                var req = new HttpRequestMessage(HttpMethod.Post, RequestUrl) { Content = payload };
                var response = await client.SendAsync(req);
                if (response?.IsSuccessStatusCode ?? false)
                {
                    var condition = await response.Content.ReadAsStringAsync();
                    var deserialData=   JsonConvert.DeserializeObject<List<StackHolderAndOfficerSpecifcConditions>>(condition);
                    int index = 1;
                    foreach (var CItem in deserialData)
                    {
                        Result.Add(new StackHolderAndOfficerSpecifcConditions
                        {
                            IndexNumber=index++,
                             CommentType =CItem.CommentType,
                              condition=CItem.condition,
                               Order=CItem.Order,
                                StakeholderName=CItem.StakeholderName,
                                 SubSortOrder=CItem.SubSortOrder,
                                  TRA_SPECCOND_ID=CItem.TRA_SPECCOND_ID,
                                   viewReview=CItem.viewReview,
                                    ViewDoc=CItem.ViewDoc

                        });
                    }


                }

                string transactionNumber = Session.Instance.CurrentTransaction.Transaction.TransactionNumber;
                var useraddedConditions = await ApiService.Instance.GenericPostApiCall(Urls.getOfficerResponsepageConditionsForReviewerUserConditions + transactionNumber + "/" + "reviewer");
                if (!string.IsNullOrEmpty(useraddedConditions))
                {
                    ReviewerConditionInReviewerPageModel uCondition = JsonConvert.DeserializeObject<ReviewerConditionInReviewerPageModel>(useraddedConditions);
                    int index = 1;
                    foreach (var CItem in uCondition.UserSpCondition)
                    {
                        Result.Add(new StackHolderAndOfficerSpecifcConditions
                        {
                            IndexNumber = index++,
                            CommentType = CItem.COMMENTTYPE,
                            condition = CItem.CONDITIONS,

                            //StakeholderName = CItem.StakeholderName,
                            // SubSortOrder = CItem.SubSortOrder,
                            TRA_SPECCOND_ID = CItem.TRA_SPECCOND_ID,
                            //   viewReview = CItem.viewReview,
                            //  ViewDoc = CItem.ViewDoc

                        });
                    }

                }
                

            }
            catch (Exception ex)
            {
                

            }
            return Result;
        }
    }
}
