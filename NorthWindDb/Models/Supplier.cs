using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }

    public class SupplierConfiguration:EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            HasKey(k => k.Id);
            Property(p => p.CompanyName).HasMaxLength(40);
            Property(p => p.ContactName).HasMaxLength(30);
            Property(p => p.ContactTitle).HasMaxLength(30);
            Property(p => p.Address).HasMaxLength(60);
            Property(p => p.City).HasMaxLength(15);
            Property(p => p.Region).HasMaxLength(15);
            Property(p => p.PostalCode).HasMaxLength(10);
            Property(p => p.Country).HasMaxLength(15);
            Property(p => p.Phone).HasMaxLength(24);
            Property(p => p.Fax).HasMaxLength(24);
            Property(p => p.HomePage).HasColumnType("ntext");
        }
    }
}
