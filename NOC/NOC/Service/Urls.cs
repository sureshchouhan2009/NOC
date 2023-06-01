using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Service
{
    public class Urls
    {
       

        public const string BaseUrl = "https://portal.gpceast.com/noc/";//dev latest (UAT OR Dev)
         // public const string BaseUrl = "https://noc.etihadrail.ae/noc/";//prod (Production)


        public const string TokenURL = BaseUrl + "Token";
        public const string Gettokenurls = BaseUrl+"api/Account/UserInfo";
        public const string CheckApplicant = BaseUrl + "api/Users/CheckApplicant";
        public const string CheckReviewer = BaseUrl + "api/Users/CheckReviewer";
        public const string CheckStakeholder = BaseUrl + "api/Users/ERStakeholder";
        public const string CheckOfficer = BaseUrl + "api/Users/CheckOfficer";
        public const string GetAttachmentsTypesForDD = BaseUrl + "api/Attachments/GetAttachmenttype";




        #region UserSpecific SearchCount 
        public const string GetSearchCountApplicant = BaseUrl + "api/Search/GetSearchCount/applicant";
        public const string GetSearchCountOfficer = BaseUrl + "api/Search/GetSearchCount/processor";
        public const string GetSearchCountStackHolder = BaseUrl + "api/Search/GetSearchCount/stakeholder";
        public const string GetSearchCountReviewer = BaseUrl + "api/Search/GetSearchCount/reviewer";
        #endregion

        #region UserSpecific ApplicationLists 
        public const string applicantGetTransactionList = BaseUrl + "api/Search/GetTransactionList/applicant/";
        public const string OfficerGetTransactionList = BaseUrl + "api/Search/GetTransactionList/processor/";
        public const string stakeholderTransactionList = BaseUrl + "api/Search/GetTransactionList/stakeholder/";
        public const string reviewerGetTransactionList = BaseUrl + "api/Search/GetTransactionList/reviewer/";
        #endregion

        //  public const string applicantGetTransactionList = BaseUrl + "api/Search/GetTransactionList/applicant/";//in last we need to pass filter id

        public const string GetNotifications = BaseUrl + "api/Search/GetNotification";
        public const string GetTransactionDetails = BaseUrl + "api/Transaction/gettrandata/";//in last we need to pass transaction Application Number
        public const string GetTransactionDetailsNew = BaseUrl + "api/SearchOfficer/process/";//in last we need to pass transaction Application Number

        //api/SearchOfficer/process/{tranid}
        public const string GetTransactionCommentsForProcessor = BaseUrl + "api/comment/getcommentdatalistProcessor/";// specific for processor

        public const string GetTransactionAttachment = BaseUrl + "api/Attachments/GetAttachments/?transactionid=";//{173}in last we need to pass transaction ID
        public const string GetTransactionComents = BaseUrl + "api/comment/getcommentdatalist/";//{RKT-20220329-1003}in last we need to pass Application Number
        public const string CommentSaveing = BaseUrl + "api/search/commentsaveing";//add the new or reply comment.
        public const string EditsaveEditSave = BaseUrl + "api/search/Editsave";//update the existing comment. 

        // this method actually saves the file path to the DB     
        public const string SaveAttachmentToDatabase = BaseUrl + "api/Attachments/SaveCommentAttachment";//api/Attachments/SaveCommentAttachment. 

        //as requested new endpoint created for Mobile uploads
        //for mobile this method saves actual file to the server folder structure and returns the file path
        public const string UploadAttachmentToServer = BaseUrl + "api/Attachments/MobileFileUpload";


        #region Reviewer Specific Urls
        public const string PostObjectionRaised = BaseUrl + "api/ERReviewer/ObjectionRaised";
        public const string PostNoObjection = BaseUrl + "api/ERReviewer/NoObjection";
        public const string GetCommentsRelatedAttachment = BaseUrl + "api/search/GetCommentsRelatedAttachment/";
        public const string SaveStakeholderResponseAttachment = BaseUrl + "api/Attachments/SaveStakeholderResponseAttachment";
        #endregion
        #region Processor Specific Urls

        public const string PostOwnNocs = BaseUrl + "api/SearchOfficer/OwnProcessor";
        public const string TransferOwnership = BaseUrl + "api/TransactionService/TransferOwnership";

        #endregion



        public const string GetStackholderList = BaseUrl + "api/search/GetAssociatedStakeholder/";//319
        public const string GetAllStackholderResponsedata = BaseUrl + "api/search/togetcountpageloadcomntsforReview/";//319
        public const string GetStackholderRelatedAttachment = BaseUrl + "api/search/GetCommentsRelatedAttachment/";//157
        public const string GetReviewerSpecificComment = BaseUrl + "api/search/GetReviewerSpecificComment/";//319
        public const string PostDecisionCommentsave = BaseUrl + "api/search/DecisionCommentsave";//ToSaveNewComment in reviewerPage
        public const string PostDecisionCommentUpdate = BaseUrl + "api/search/Responcesaveingupdate";//ToUpdateComment in reviewerPage

        public const string SpecificConditionGetAllStakeHolderResponse = BaseUrl+"api/SpecificCondition/GetAllStakeHolderResponse/";//319
        public const string SaveSpecificCondition = BaseUrl + "api/SpecificCondition/SaveSpecificCondition/"; //send the "true" for the reviewer role.
        public const string UpdatepecificCondition = BaseUrl + "api/SpecificCondition/UpdateSpecificCondition"; //update exisiting conditions


        public const string GetReviewerConditons = BaseUrl + "api/SpecificCondition/GetReviewerConditons/";//RKT-20220407-1004
        public const string deleteReviewerSpecificCustomConditions=BaseUrl+ "api/SpecificCondition/DeleteUserspecificcondition/"; //conditionid
        public const string transferOwnerUserList=BaseUrl+ "api/Users/TransferOwner";


        //to save fresh new comments from applicant{methods post}
        public const string SaveApplicatNewComment = BaseUrl + "api/search/commentsaveing";//its just saves to server yet to submit
        public const string SubmitCommentsForApplicant = BaseUrl + "api/SearchOfficer/SubmitCommentApplicant";//submit anather call we need to perform for applicat
        public const string SubmitCommentsForProcessor = BaseUrl + "api/SearchOfficer/SubmitCommentProcessor";//submit anather call we need to perform for applicat

        //to save fresh new comments from Internal Comments{methods post}
        public const string SaveNewCommentForInternal = BaseUrl + "api/search/commentsaveing";//just save enough


    }
}
