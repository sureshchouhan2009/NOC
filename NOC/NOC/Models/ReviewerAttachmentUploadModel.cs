using System;
using System.Collections.Generic;

namespace NOC.Models.ReviwerSpecific
{
   



    public class Attachments
    {
        public int TransactionID { get; set; }

    }

   

    public class ReviewerAttachmentUploadModel
    {
        public Attachments attachments { get; set; }
        public List<Attchtypeandfilepath> attchtypeandfilepath { get; set; } = new List<Attchtypeandfilepath>();
        public string RandomID { get; set; }
        public string TransactionNumber { get; set; }


        public string Workflow { get; set; }
    }




    //var attachments = {
    //    "TransactionID": transactionid,
    //    /*"UserID": userid,*/
    //}


    //var data = {
    //    "attachments": attachments,
    //    "attchtypeandfilepath": uploadfiles,
    //    "RandomID": randomid,
    //    "TransactionNumber": transactionno,
    //    "Workflow": localStorage.getItem("Workflow"),
    //}
}
