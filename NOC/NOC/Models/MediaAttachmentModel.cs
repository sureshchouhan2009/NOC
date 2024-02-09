using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NOC.Models
{
   
   



    public class Attachments
    {
        public int TransactionID { get; set; }
        public string UserID { get; set; }
    }

    public class Attchtypeandfilepath
    {
        public int Attachmenttype { get; set; }
        public string filepath { get; set; }
        public int commentID { get; set; }
        public string typeofsave { get; set; }
    }

    public class MediaAttachmentModel
    {
        public Attachments attachments { get; set; }
        public List<Attchtypeandfilepath> attchtypeandfilepath { get; set; } = new List<Attchtypeandfilepath>();
        public string RandomID { get; set; }
        public string TransactionNumber { get; set; }
    }
}
