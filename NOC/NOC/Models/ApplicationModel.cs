using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Models
{
    
    public class TransactionModel
    {
        public int UID { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int TransactionID { get; set; }
        public string NOCType { get; set; }
        public string Project { get; set; }
        public string Service { get; set; }
        public string Client { get; set; }
        public string Applicant { get; set; }
        public int TimetoRespond { get; set; }
        public int SLA { get; set; }
        public string STATUS { get; set; }
        public string EmirateCode { get; set; }

        public string ReplyUserName { get; set; }
        public string WorkFlow { get; set; }
        public int REPLY_SEQ_ID { get; set; }
        public string ER_OUTCOME_CODE { get; set; }
        public int STEP_CODE { get; set; }

    }
}
