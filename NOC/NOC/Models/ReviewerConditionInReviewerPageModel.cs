using System;
using System.Collections.Generic;

namespace NOC.Models
{
    public class ReviewerConditionInReviewerPageModel
    {
        public List<SystemSpCondition> SystemSpCondition { get; set; } = new List<SystemSpCondition>();
        public List<UserSpCondition> UserSpCondition { get; set; } = new List<UserSpCondition>();
    }

    public class SystemSpCondition
    {
        public int TRA_SPECCOND_ID { get; set; }
        public string CONDITIONS { get; set; }
        public int TRANSACTIONID { get; set; }
        public object USERID { get; set; }
        public int SOLUTIONROLEID { get; set; }
        public int STAKEHOLDERID { get; set; }
        public string COMMENTTYPE { get; set; }
        public object CreatedBy { get; set; }
        public object CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }
    public class UserSpCondition
    {
        public int TRA_SPECCOND_ID { get; set; }
        public string CONDITIONS { get; set; }
        public int TRANSACTIONID { get; set; }
        public string USERID { get; set; }
        public int SOLUTIONROLEID { get; set; }
        public int STAKEHOLDERID { get; set; }
        public string COMMENTTYPE { get; set; }
        public object CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }
    

    public class SystemAndUserSpCondition
    {
        public int IndexNumber { get; set; }
        public int TRA_SPECCOND_ID { get; set; }
        public string CONDITIONS { get; set; }
        public int TRANSACTIONID { get; set; }
        public object USERID { get; set; }
        public int SOLUTIONROLEID { get; set; }
        public int STAKEHOLDERID { get; set; }
        public string COMMENTTYPE { get; set; }
        public object CreatedBy { get; set; }
        public object CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }
}
