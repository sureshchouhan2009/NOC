using System;
namespace NOC.Models
{
    public class StackholderUserCheckModel
    {
       
            public object Transaction { get; set; }
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
            public int SolutionRoleUser { get; set; }
            public object Attachments { get; set; }
            public StakeholderComments Stakeholder_Comments { get; set; }
            public object Decision { get; set; }
            public object SolutionRoleswithUserID { get; set; }
            public object specificcondition { get; set; }
            public object ConditionsList { get; set; }
            public object emirates { get; set; }
        }

        public class StakeholderComments
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

