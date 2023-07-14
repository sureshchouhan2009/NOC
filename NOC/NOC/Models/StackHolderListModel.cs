﻿using System;
namespace NOC.Models
{
    public class StackHolderListModel
    {
        
            public int SthcmntID { get; set; }
            public int Decision { get; set; }
            public object Comment { get; set; }
            public int TransactionID { get; set; }
            public DateTime DecisionDate { get; set; }
            public int StakeholderID { get; set; }
            public int UserSolutionRole { get; set; }
            public string UserID { get; set; }
            public int DecisionID { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreationDate { get; set; }
            public object LastModifiedBy { get; set; }
            public DateTime LastModificationDate { get; set; }
            public string WorkFlow { get; set; }
       
    }
}
