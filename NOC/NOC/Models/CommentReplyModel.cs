using System;
namespace NOC.Models
{
    
    public class CommentReplyModel
    {
        public int CommentType { get; set; }
        public int TransactionID { get; set; }
        public DateTime CommentsDate { get; set; }
        public string UserID { get; set; }
        public string Comment { get; set; }
        public int ParentCommentID { get; set; }
    }


}
