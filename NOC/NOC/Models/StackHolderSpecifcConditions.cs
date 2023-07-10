using System;
namespace NOC.Models
{
    /// <summary>
    /// Stack holder response page Condition Model
    /// </summary>
    public class StackHolderAndOfficerSpecifcConditions
    {
       
            public int TRA_SPECCOND_ID { get; set; }
            public string StakeholderName { get; set; }
            public string condition { get; set; }
            public object CommentType { get; set; }
            public object SubSortOrder { get; set; }
            public bool ViewDoc { get; set; }
            public int Order { get; set; }
            public bool viewReview { get; set; }

    }

    
}
