using System;
namespace NOC.Models
{
    public class StackHolderFilterModel
    {
       
            public int ERStakeHoldersID { get; set; }
            public string ERStakeHoldersCode { get; set; }
            public int SortOrder { get; set; }
            public object LastModificationDate { get; set; }
            public object ERGroup { get; set; }
            public int SolutionRoleID { get; set; }
            public bool IsDeleted { get; set; }
    }
}
