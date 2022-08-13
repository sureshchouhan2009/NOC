using System;
namespace NOC.Models
{
    public class SaveNewCommentFromApplicantModel
    {
        public int CommentType { get; set; }
        public int TransactionID { get; set; }
        public DateTime CommentsDate { get; set; }
        public string UserID { get; set; }
        public string Comment { get; set; }
    }

    //
   
}
