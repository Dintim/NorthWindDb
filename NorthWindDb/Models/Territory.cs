using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Territory
    {
        public string Id { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Territory()
        {
            Employees = new List<Employee>();
        }
    }

    public class TerritoryConfiguration : EntityTypeConfiguration<Territory>
    {
        public TerritoryConfiguration()
        {
            HasKey(k => k.Id);
            Property(p => p.Id).HasMaxLength(20);
            Property(p => p.TerritoryDescription).HasColumnType("nchar").HasMaxLength(50);
        }
    }
}
