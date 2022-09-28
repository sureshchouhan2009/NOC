using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Models
{

    public class LinkedNOCTransactions
    {
        public int ID { get; set; }
        public string RelatedNOCTransactionID { get; set; }
        public int TransactionID { get; set; }
        public string ExternalNOCTransactionNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string OrganizationLicenseNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
        public int Emirate { get; set; }
    }

    public class Owner
    {
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string ClientName { get; set; }
        public string ClientPOC { get; set; }
        public string ClientEmail { get; set; }
        public string ClientMobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }

    public class ProjectActivityCategory
    {
        public int ProjectActivityCategoryID { get; set; }
        public string ProjectActivityCategoryCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class ProjectActivitySubType
    {
        public int ProjectActivitySubTypeID { get; set; }
        public string ProjectActivitySubTypeCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class ProjectActivityType
    {
        public int ProjectActivityTypeID { get; set; }
        public string ProjectActivityTypeCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class ProjectDetails
    {
        public Owner Owner { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ProjectedEndDate { get; set; }
        public int OwnerID { get; set; }
        public object Other { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int TransactionID { get; set; }
        public string ProjectNumber { get; set; }
    }

    public class ProjectStage
    {
        public int ProjectStageID { get; set; }
        public string ProjectStageCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    public class TransactionDetailsModel
    {
        public Transaction Transaction { get; set; }
        public ProjectDetails ProjectDetails { get; set; }
        public Users Users { get; set; }
        public UserType UserType { get; set; }
        public Organization Organization { get; set; }
        public LinkedNOCTransactions LinkedNOCTransactions { get; set; }
        public TransactionService TransactionService { get; set; }
        public ProjectActivityType ProjectActivityType { get; set; }
        public ProjectActivitySubType ProjectActivitySubType { get; set; }
        public ProjectActivityCategory ProjectActivityCategory { get; set; }
        public Owner Owner { get; set; }
        public object CommentType { get; set; }
        public object Comments { get; set; }
        public object ERStakeHolders { get; set; }
        public object T_ERStakeHolders { get; set; }
        public object Responses { get; set; }
        public object T_SpecificConditions { get; set; }
        public ProjectStage ProjectStage { get; set; }
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
    }

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
        //ADDED LATER
        public DateTime ValidUntil { get; set; }
        public bool Renew { get; set; }
        public int Unit { get; set; }
    }

    public class TransactionService
    {
        public int TransactionServiceID { get; set; }
        public string TransactionServiceCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
    }

    //public class Users
    //{
    //    public UserType UserType { get; set; }
    //    public string UserID { get; set; }
    //    public string UserName { get; set; }
    //    public int UserTypeID { get; set; }
    //    public string FirstName { get; set; }
    //    public string MiddleName { get; set; }
    //    public object ThirdName { get; set; }
    //    public string FamilyName { get; set; }
    //    public string ContactMobile { get; set; }
    //    public string ContactOfficeNumber { get; set; }
    //    public string ContactEmail { get; set; }
    //    public object ContactFaxNumber { get; set; }
    //    public object EmiratesID { get; set; }
    //    public int OrganizationID { get; set; }
    //    public int RecieveSMS { get; set; }
    //    public int RecieveEmailNotifications { get; set; }
    //    public int PreferredNotificationLanguage { get; set; }
    //    public bool ThirdPartyOrg { get; set; }
    //    public object CreatedBy { get; set; }
    //    public string RegisteredAddress { get; set; }
    //    public string Title { get; set; }
    //    public string Nationality { get; set; }
    //    public DateTime CreationDate { get; set; }
    //    public object LastModifiedBy { get; set; }
    //    public object LastModificationDate { get; set; }
    //    public object Attachments { get; set; }
    //    public Organization Organization { get; set; }
    //    public object Authentication { get; set; }
    //    public string UserId_fk { get; set; }
    //    public object Urlid { get; set; }
    //}

    //public class UserType
    //{
    //    public int UserTypeID { get; set; }
    //    public string UserTypeValue { get; set; }
    //    public int SortOrder { get; set; }
    //    public DateTime LastModificationDate { get; set; }
    //}











    //public class Transaction
    //{
    //    public int TransactionID { get; set; }
    //    public int TransactionServiceID { get; set; }
    //    public int ActivityCategoryID { get; set; }
    //    public int ActivityTypeID { get; set; }
    //    public object ContractorName { get; set; }
    //    public string UserID { get; set; }
    //    public string ConsultantName { get; set; }
    //    public int ActivitySubTypeID { get; set; }
    //    public int StageID { get; set; }
    //    public int PhaseID { get; set; }
    //    public object AdditionalDetails { get; set; }
    //    public int ReviewDecision { get; set; }
    //    public object ReviewComments { get; set; }
    //    public string TransactionNumber { get; set; }
    //    public DateTime TransactionDate { get; set; }
    //    public string Status { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreationDate { get; set; }
    //    public string LastModifiedBy { get; set; }
    //    public DateTime LastModificationDate { get; set; }
    //    public int ProjectID { get; set; }
    //    public object ApplicationType { get; set; }
    //    public int EmiratesID { get; set; }
    //}

    //public class TransactionDetailsModel
    //{
    //    public Transaction Transaction { get; set; }
    //    public object ProjectDetails { get; set; }
    //    public object Users { get; set; }
    //    public object UserType { get; set; }
    //    public object Organization { get; set; }
    //    public object LinkedNOCTransactions { get; set; }
    //    public object TransactionService { get; set; }
    //    public object ProjectActivityType { get; set; }
    //    public object ProjectActivitySubType { get; set; }
    //    public object ProjectActivityCategory { get; set; }
    //    public object Owner { get; set; }
    //    public object CommentType { get; set; }
    //    public object Comments { get; set; }
    //    public object ERStakeHolders { get; set; }
    //    public object T_ERStakeHolders { get; set; }
    //    public object Responses { get; set; }
    //    public object T_SpecificConditions { get; set; }
    //    public object ProjectStage { get; set; }
    //    public object Conditions { get; set; }
    //    public object LK_SpecificConditions { get; set; }
    //    public object TTransactionStepReply { get; set; }
    //    public object Authentication { get; set; }
    //    public object LkTransStepsReply { get; set; }
    //    public object SolutionRoles { get; set; }
    //    public object SolutionRoleUser { get; set; }
    //    public object Attachments { get; set; }
    //    public object Stakeholder_Comments { get; set; }
    //    public object Decision { get; set; }
    //    public object SolutionRoleswithUserID { get; set; }
    //}





}


