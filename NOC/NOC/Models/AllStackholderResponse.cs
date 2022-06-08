using System;
namespace NOC.Models
{
    public class AllStackholderResponse
    {
        public int SthcmntID { get; set; }
        public int Decision { get; set; }
        public string Comment { get; set; }
        public int TransactionID { get; set; }
        public DateTime DecisionDate { get; set; }
        public int StakeholderID { get; set; }
        public int UserSolutionRole { get; set; }
        public string UserID { get; set; }
        public int DecisionID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public object LastModificationDate { get; set; }
    }

}
