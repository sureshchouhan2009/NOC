using System;
namespace NOC.Models
{
    public class ObjectionOptionPostModel
    {
        public string userID { get; set; }
        public string transactionid { get; set; }
        public string expirydate { get; set; }
        public int unit { get; set; }


       
    }


    public class SentBackApplicationModel
    {
        public string sentiduserid { get; set; }
        public string StakeHoldersCodeDisplay { get; set; }
        public int sentbacktranID { get; set; }
        public int stepcode { get; set; }
    }





    public class OwnNocPostModel
    {
        public string userID { get; set; }
        public string transactionid { get; set; }
        public string workflow { get; set; }
        
    }

}
