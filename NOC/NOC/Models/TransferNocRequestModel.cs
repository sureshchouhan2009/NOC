using System;
namespace NOC.Models
{
    public class TransferNocRequestModel
    {
        public string transNumber { get; set; }
        public string transferUserId { get; set; }
        public string Type { get; set; }
        public int REPLYSEQID { get; set; }
    }
}
