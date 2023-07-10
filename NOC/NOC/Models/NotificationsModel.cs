using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Models
{
   
    public class NotificationsModel
    {
        public int NotificationID { get; set; }
        public string UserID { get; set; }
        public string Message { get; set; }
        public bool Is_Archived { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool Is_emailSent { get; set; }
        public bool IsRead { get; set; }
        public int TransactionID { get; set; }
        public object EmailMessage { get; set; }
        public object Greetings { get; set; }

        public string TransactionNumber { get; set; }
    }
}
