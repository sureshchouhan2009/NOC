using System;
namespace NOC.Models
{
    public class StackholderTypeCheckModel
    {
        public int UsersSolutionRolesID { get; set; }
        public string UserID { get; set; }
        public int SolutionRoleID { get; set; }
        public bool IsDefaultUserinRole { get; set; }
        public int DefaultValue { get; set; }
        public bool DelegateReassign { get; set; }
        public object ComplaintDefaultValue { get; set; }
        public object ClaimDefaultValue { get; set; }
        public bool SlaExpiryDefaultUser { get; set; }
        public int DefaultRole { get; set; }
        public object CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }






}
