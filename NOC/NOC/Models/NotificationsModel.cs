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
        public string LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
    }
}
