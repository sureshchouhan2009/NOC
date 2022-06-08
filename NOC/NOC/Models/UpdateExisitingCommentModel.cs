using System;
namespace NOC.Models
{
    public class UpdateExisitingCommentModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public int radiovalue { get; set; }
        public string expirydate { get; set; }
        public int transactionid { get; set; }
    }
}
