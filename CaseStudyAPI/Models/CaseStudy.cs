using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("casestudies")]
    public class CaseStudy
    {
        #region "TableAttributes"
        [Column("casestudyid")]
        public int Id { get; set; }

        [Column("engagementname")]
        [MaxLength(255)]
        public string EngagementName { get; set; }

        [Column("businessproblem")]
        [MaxLength(255)]
        public string BusinessProblem { get; set; }

        [Column("solutiondescription")]
        [MaxLength(512)]
        public string SolutionDescription { get; set; }

        [Column("industryid")]
        public int IndustryId { get; set; }

        [Column("practiceid")]
        public int PracticeId { get; set; }

        [Column("staffingdeliverymodelid")]
        public int StaffingDeliveryModelId { get; set; }

        [Column("engagementrevenue")]
        public int EngagementRevenue { get; set; }

        [Column("engagementduration")]
        public int EngagementDuration { get; set; }

        [Column("engagementsize")]
        public int EngagementSize { get; set; }

        [Column("valuestatement")]
        [MaxLength(512)]
        public string ValueStatement { get; set; }

        [Column("username")]
        [MaxLength(255)]
        public string UserName { get; set; }
        #endregion  

        #region "Relationships"

        public Practice Practice { get; set; }
        public StaffingDeliveryModel StaffingDeliveryModel { get; set; }
        public Industry Industry { get; set; }


        public ICollection<CaseStudyTechnology> CaseStudyTechnologies { get; set; }
        #endregion  
    }
}
