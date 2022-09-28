using System;
namespace NOC.Models.ReviwerSpecific
{
   

    public class Comments
    {
        public string Comment { get; set; }
        public int Decision { get; set; }
        public string UserID { get; set; }
        public int TransactionID { get; set; }
        public int DecisionID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int StakeholderID { get; set; }
        public DateTime DecisionDate { get; set; }
    }

    public class PostCommentModel
    {
        public Comments comments { get; set; }
        public string expirydate { get; set; }
        public bool isAvaliable { get; set; }
        public int unit { get; set; }
    }
}
