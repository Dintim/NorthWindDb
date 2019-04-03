using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int ? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public virtual Employee Supervisor { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }
        public Employee()
        {
            Subordinates = new List<Employee>();
            Orders = new List<Order>();
            Territories = new List<Territory>();
        }
        
    }

    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.EmployeeId);
            HasMany(p => p.Subordinates)
                .WithOptional(p => p.Supervisor)
                .HasForeignKey(p => p.ReportsTo);
            HasMany(p => p.Territories).WithMany(p => p.Employees).Map(p =>
            {
                p.MapLeftKey("EmployeeId");
                p.MapRightKey("TerritoryId");
                p.ToTable("EmployeeTerritories");
            });

            Property(p => p.Photo).HasColumnType("image");
            Property(p => p.LastName).HasMaxLength(20);
            Property(p => p.FirstName).HasMaxLength(10);
            Property(p => p.Title).HasMaxLength(30);
            Property(p => p.TitleOfCourtesy).HasMaxLength(25);
            Property(p => p.Address).HasMaxLength(60);
            Property(p => p.City).HasMaxLength(15);
            Property(p => p.Region).HasMaxLength(15);
            Property(p => p.PostalCode).HasMaxLength(10);
            Property(p => p.Country).HasMaxLength(15);
            Property(p => p.HomePhone).HasMaxLength(24);
            Property(p => p.Extension).HasMaxLength(4);
            Property(p => p.PhotoPath).HasMaxLength(255);
        }
    }
}
