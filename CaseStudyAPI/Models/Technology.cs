using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("technologies")]
    public class Technology
    {
        #region "TableAttributes"
        [Column("technologyid")]
        public int Id { get; set; }

        [Column("technologyname")]
        [MaxLength(255)]
        public string TechnologyName { get; set; }
        #endregion

        #region "Relationships"
        public ICollection<CaseStudyTechnology> CaseStudyTechnologies { get; set; }
        #endregion  
    }
}
