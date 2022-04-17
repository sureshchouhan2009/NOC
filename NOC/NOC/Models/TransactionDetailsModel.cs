using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Models
{
    
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TransactionServiceID { get; set; }
        public int ActivityCategoryID { get; set; }
        public int ActivityTypeID { get; set; }
        public object ContractorName { get; set; }
        public string UserID { get; set; }
        public string ConsultantName { get; set; }
        public int ActivitySubTypeID { get; set; }
        public int StageID { get; set; }
        public int PhaseID { get; set; }
        public object AdditionalDetails { get; set; }
        public int ReviewDecision { get; set; }
        public object ReviewComments { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int ProjectID { get; set; }
        public object ApplicationType { get; set; }
        public int EmiratesID { get; set; }
    }

    public class TransactionDetailsModel
    {
        public Transaction Transaction { get; set; }
        public object ProjectDetails { get; set; }
        public object Users { get; set; }
        public object UserType { get; set; }
        public object Organization { get; set; }
        public object LinkedNOCTransactions { get; set; }
        public object TransactionService { get; set; }
        public object ProjectActivityType { get; set; }
        public object ProjectActivitySubType { get; set; }
        public object ProjectActivityCategory { get; set; }
        public object Owner { get; set; }
        public object CommentType { get; set; }
        public object Comments { get; set; }
        public object ERStakeHolders { get; set; }
        public object T_ERStakeHolders { get; set; }
        public object Responses { get; set; }
        public object T_SpecificConditions { get; set; }
        public object ProjectStage { get; set; }
        public object Conditions { get; set; }
        public object LK_SpecificConditions { get; set; }
        public object TTransactionStepReply { get; set; }
        public object Authentication { get; set; }
        public object LkTransStepsReply { get; set; }
        public object SolutionRoles { get; set; }
        public object SolutionRoleUser { get; set; }
        public object Attachments { get; set; }
        public object Stakeholder_Comments { get; set; }
        public object Decision { get; set; }
        public object SolutionRoleswithUserID { get; set; }
    }
}
