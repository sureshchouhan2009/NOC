using System;
namespace NOC.Models
{
    public class AttachmentsTypesResourceModel
    {
        public int AttachmentTypeID { get; set; }
        public string AttachmentTypeCode { get; set; }
        public int SortOrder { get; set; }
        public bool Isvisible { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }

}
