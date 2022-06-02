﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Service
{
    public class Urls
    {
        public const string BaseUrl = "https://portal.gpceast.com/er/noc/";


        public const string TokenURL = BaseUrl + "Token";
        public const string CheckApplicant = BaseUrl + "api/Users/CheckApplicant";
        public const string CheckReviewer = BaseUrl + "api/Users/CheckReviewer";
        public const string CheckStakeholder = BaseUrl + "api/Users/ERStakeholder";
        public const string CheckOfficer = BaseUrl + "api/Users/CheckOfficer";



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
        #endregion
        #region Processor Specific Urls

        public const string PostOwnNocs = BaseUrl + "api/SearchOfficer/OwnProcessor";
        public const string TransferOwnership = BaseUrl + "api/TransactionService/TransferOwnership";

        #endregion



        public const string GetStackholderList = BaseUrl + "api/search/GetAssociatedStakeholder/";//319

    }
}
