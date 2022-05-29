using System;
namespace NOC.Models
{
    

    public class StackholderModel
    {
        public int ERStakeHoldersID { get; set; }
        public string ERStakeHoldersCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string ERGroup { get; set; }
        public int SolutionRoleID { get; set; }
    }
}
