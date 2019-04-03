using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class CustomerDemographic
    {
        public string TypeId { get; set; }
        public string CustomerDescription { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public CustomerDemographic()
        {
            Customers = new List<Customer>();
        }
    }

    public class CustomerDemographicConfiguration : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration()
        {
            HasKey(k => k.TypeId);
            Property(p => p.TypeId).HasColumnType("nchar").HasMaxLength(10);
            Property(p => p.CustomerDescription).HasColumnType("ntext");
        }
    }
}
