using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Service
{
    public class Urls
    {
        public const string BaseUrl = "https://portal.gpceast.com/er/noc/";


        public const string TokenURL = BaseUrl + "Token";

        public const string GetSearchCount = BaseUrl + "api/Search/GetSearchCount/applicant";
        public const string GetNotifications = BaseUrl + "api/Search/GetNotification";

    }
}
