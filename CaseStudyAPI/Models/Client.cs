using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    [Table("clients")]
    public class Client
    {
        #region "Table Attributes"
        [Column("clientid")]
        public int Id { get; set; }

        [Column("clientname")]
        [MaxLength(255)]
        public string ClientName { get; set; }
        #endregion

        #region "Relationships"
        public ICollection<CaseStudy> CaseStudies { get; set; }
        #endregion  
    }
}
