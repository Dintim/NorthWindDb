using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionRescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }

        public Region()
        {
            Territories = new List<Territory>();
        }
    }

    public class RegionConfiguration: EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(k => k.Id);
            Property(p => p.RegionRescription).HasColumnType("nchar").HasMaxLength(50);
        }
    }
}
