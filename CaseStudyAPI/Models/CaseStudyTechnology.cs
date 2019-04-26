using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("casestudytechnologies")]
    public class CaseStudyTechnology
    {
        #region "Table Attributes"
        [Column("casestudytechid")]
        public int Id { get; set; }

        [Column("technologyid")]
        public int TechnologyId { get; set; }
        [Column("casestudyid")]
        public int CaseStudyId { get; set; }

        #endregion

        #region "Relationships"
        public CaseStudy CaseStudy { get; set; }

        public Technology Technology { get; set; }
        #endregion  
    }
}
