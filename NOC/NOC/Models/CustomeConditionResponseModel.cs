using System;
namespace NOC.Models
{
    public class CustomeConditionResponseModel
    {
            public int TRA_SPECCOND_ID { get; set; }
            public string CONDITIONS { get; set; }
            public int TRANSACTIONID { get; set; }
            public string USERID { get; set; }
            public int SOLUTIONROLEID { get; set; }
            public int STAKEHOLDERID { get; set; }
            public string COMMENTTYPE { get; set; }
            public object SubSortOrder { get; set; }
            public object CreatedBy { get; set; }
            public DateTime CreationDate { get; set; }
            public object LastModifiedBy { get; set; }
            public object LastModificationDate { get; set; }
            public string WorkFlow { get; set; }
            public bool ViewReviewr { get; set; }
            public bool ViewDoc { get; set; }

    }
    }

