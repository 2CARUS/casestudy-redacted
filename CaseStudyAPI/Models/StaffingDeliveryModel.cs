using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("staffingdeliverymodels")]
    public class StaffingDeliveryModel
    {
        #region "TableAttributes"
        [Column("modelid")]
        public int Id { get; set; }

        [Column("modelname")]
        [MaxLength(255)]
        public string ModelName { get; set; }
        #endregion

        #region "Relationships"
        public ICollection<CaseStudy> CaseStudies { get; set; }
        #endregion
    }
}
