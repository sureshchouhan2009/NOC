using System;
namespace NOC.Models
{
    public class AttachmentTypeModel
    {
        public int AttachmentTypeID { get; set; }
        public string AttachmentTypeCode { get; set; }
        public int SortOrder { get; set; }
        public bool Isvisible { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
