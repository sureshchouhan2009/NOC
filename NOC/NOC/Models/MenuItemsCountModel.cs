using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Models
{
   

    public class MenuItemsCountModel
    {
        public string CommentedApplicationsCount { get; set; }
        public string MyNOCApplicationsCount { get; set; }
        public string OwnedApplicationsCount { get; set; }
        public string ForRevalidationInTwoWeeksCount { get; set; }
        public string OwnedApplicationsPendingTenDayCount { get; set; }
        public string FinalClearanceCount { get; set; }
        public string ForwardedCount { get; set; }
        public string CommentReplyCount { get; set; }
        public string DraftCount { get; set; }
        public string NewNOCApplicationsCount { get; set; }
        public string NotificationCount { get; set; }
        public string CompletedApplication { get; set; }
        public string SentBack { get; set; }
        public string received { get; set; }
        public string Transferapplication { get; set; }
        public string Reaject { get; set; }
        public string InProgressApplicationsCount { get; set; }
        public string ApplicationExpiredTenDays { get; set; }

    }
}
