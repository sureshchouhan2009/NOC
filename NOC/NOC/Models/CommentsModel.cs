using System;
namespace NOC.Models
{
   



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeValue { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class Users
    {
        public UserType UserType { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int UserTypeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public object ThirdName { get; set; }
        public string FamilyName { get; set; }
        public string ContactMobile { get; set; }
        public string ContactOfficeNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFaxNumber { get; set; }
        public object EmiratesID { get; set; }
        public int OrganizationID { get; set; }
        public int RecieveSMS { get; set; }
        public int RecieveEmailNotifications { get; set; }
        public int PreferredNotificationLanguage { get; set; }
        public bool ThirdPartyOrg { get; set; }
        public object CreatedBy { get; set; }
        public string RegisteredAddress { get; set; }
        public string Title { get; set; }
        public string Nationality { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
        public object Attachments { get; set; }
        public object Organization { get; set; }
        public object Authentication { get; set; }
        public string UserId_fk { get; set; }
        public object Urlid { get; set; }
        public string UserStatus { get; set; }
        public object SolutionRoleUsers { get; set; }
    }

    public class Comments
    {
        public int CommentsID { get; set; }
        public int CommentType { get; set; }
        public string Comment { get; set; }
        public int TransactionID { get; set; }
        public DateTime CommentsDate { get; set; }
        public string FormatedCommentsDate { get; set; }
        public int? ParentCommentID { get; set; }
        public bool IS_Submitted { get; set; }
        public string UserID { get; set; }
        public string UserSolutionRole { get; set; }
        public object CreatedBy { get; set; }
        public object CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
        public object IS_ApplicantSubmitted { get; set; }
    }

    public class SolutionRoleswithUserID
    {
        public string UserID { get; set; }
        public int SolutionRoleID { get; set; }
        public string SolutionRoleName { get; set; }
        public int UsersSolutionRolesID { get; set; }
    }

    public class CommentsModel
    {
        public object Transaction { get; set; }
        public object ProjectDetails { get; set; }
        public Users Users { get; set; }
        public object UserType { get; set; }
        public object Organization { get; set; }
        public object LinkedNOCTransactions { get; set; }
        public object TransactionService { get; set; }
        public object ProjectActivityType { get; set; }
        public object ProjectActivitySubType { get; set; }
        public object ProjectActivityCategory { get; set; }
        public object Owner { get; set; }
        public object CommentType { get; set; }
        public Comments Comments { get; set; }
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
        public SolutionRoleswithUserID SolutionRoleswithUserID { get; set; }

        public bool IsReplyViewVisible { get; set; } 
    }


}
