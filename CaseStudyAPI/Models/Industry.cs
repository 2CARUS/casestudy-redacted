using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("industries")]
    public class Industry
    {
        #region "Table Attributes"
        [Column("industryid")]
        public int Id { get; set; }

        [Column("industryname")]
        [MaxLength(255)]
        public string IndustryName { get; set; }
        #endregion

        #region "Relationships"
        public ICollection<CaseStudy> CaseStudies { get; set; }
        #endregion

    }
}
