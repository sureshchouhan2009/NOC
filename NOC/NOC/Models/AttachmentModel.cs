using System;
namespace NOC.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AttachmentModel
    {
        public int AttachmentID { get; set; }
        public int AttachmentTypeID { get; set; }
        public string FileName { get; set; }
        public string AttachmentTypeCode { get; set; }
        public DateTime UploadedDate { get; set; }
        public string FormatedUplodedDate { get; set; }
        public string UserID { get; set; }
        public string FilePath { get; set; }
        public int CommentsID { get; set; }
        public string UserSolutionRole { get; set; }
        public bool IsSelected { get; set; }
        public int TransactionID { get; set; }
        public string UrlPath { get; set; }
        public string uploadfilename { get; set; }
        public int OrganizationID { get; set; }
        public int SolutionRoleID { get; set; }
    }


}
