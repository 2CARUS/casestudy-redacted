using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }

        #region DbSets
        public DbSet<CaseStudy> CaseStudies { get; set; }
        public DbSet<CaseStudyTechnology> CaseStudyTechnologies { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<StaffingDeliveryModel> StaffingDeliveryModels { get; set;  }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EngagementModel> EngagementModels { get; set; }
        #endregion
     }
}
