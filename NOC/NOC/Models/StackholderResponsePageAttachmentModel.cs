using System;
using System.Collections.Generic;

namespace NOC.Models
{
   

    public class Decision
    {
        public int DecisionID { get; set; }
        public string Decision_Desc { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class StackholderResponsePageAttachmentModel
    {
        public Stakeholdercomments Stakeholdercomments { get; set; }
        public List<StakeHolderAttachment> StakeHolderAttachments { get; set; }
    }

    public class StakeHolderAttachment
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
        public object OrganizationID { get; set; }
        public int SolutionRoleID { get; set; }
        public bool Issubmitted { get; set; }
        public bool ViewReviewr { get; set; }
        public bool ViewDoc { get; set; }
        public bool Processorapplicantcomment { get; set; }
        public string WorkFlow { get; set; }
    }

    public class Stakeholdercomments
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
        public object SolutionRoleUser { get; set; }
        public object Attachments { get; set; }
        public StakeholderComments Stakeholder_Comments { get; set; }
        public Decision Decision { get; set; }
        public object SolutionRoleswithUserID { get; set; }
        public object specificcondition { get; set; }
        public object ConditionsList { get; set; }
        public object emirates { get; set; }
    }

    public class StakeholderComments2
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
