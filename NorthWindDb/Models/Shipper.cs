using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Shipper()
        {
            Orders = new List<Order>();
        }
    }

    public class ShipperConfiguration : EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            HasKey(k => k.Id);
            HasMany(m => m.Orders).WithOptional().HasForeignKey(k => k.ShipVia);

            Property(p => p.CompanyName).HasMaxLength(40);
            Property(p => p.Phone).HasMaxLength(24);
        }
    }
}
