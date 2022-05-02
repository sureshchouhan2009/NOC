using System;
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

        public const string GetSearchCount = BaseUrl + "api/Search/GetSearchCount/applicant";
        public const string GetNotifications = BaseUrl + "api/Search/GetNotification";
        public const string applicantGetTransactionList = BaseUrl + "api/Search/GetTransactionList/applicant/";//in last we need to pass filter id
        public const string GetTransactionDetails = BaseUrl + "api/Transaction/gettrandata/";//in last we need to pass transaction Application Number
        public const string GetTransactionAttachment = BaseUrl + "api/Attachments/GetAttachments/?transactionid=";//{173}in last we need to pass transaction ID
        public const string GetTransactionComents = BaseUrl + "api/comment/getcommentdatalist/";//{RKT-20220329-1003}in last we need to pass Application Number


    }
}
