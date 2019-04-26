using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("engagementmodels")]
    public class EngagementModel
    {
        #region "Table Attributes"
        [Column("engagementmodelid")]
        public int Id { get; set; }

        [Column("engagementmodellevel")]
        [MaxLength(255)]
        public string EngagementModelLevel { get; set; }
        #endregion

        //#region "Relationships"
        //public ICollection<CaseStudy> CaseStudies { get; set; }
        //#endregion  
    }
}