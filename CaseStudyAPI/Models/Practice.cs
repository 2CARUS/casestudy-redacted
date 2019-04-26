using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("practices")]
    public class Practice
    {
        #region "Table Attributes"
        [Column("practiceid")]
        public int Id { get; set; }

        [Column("practicename")]
        [MaxLength(255)]
        public string PracticeName { get; set; }
        #endregion

        //#region "Relationships"
        //public ICollection<CaseStudy> CaseStudies { get; set; }
        //#endregion  
    }
}
