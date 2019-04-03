﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Fright { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Shipper Shipper { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    public class OrderConfiguration: EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(p => p.Id);
            HasMany(p => p.OrderDetails)
                .WithRequired()
                .HasForeignKey(p => p.OrderId);
            Property(p => p.CustomerId).HasColumnType("nchar").HasMaxLength(5);
            Property(p => p.ShipName).HasMaxLength(40);
            Property(p => p.ShipAddress).HasMaxLength(60);
            Property(p => p.ShipCity).HasMaxLength(15);
            Property(p => p.ShipRegion).HasMaxLength(15);
            Property(p => p.ShipPostalCode).HasMaxLength(10);
            Property(p => p.ShipCountry).HasMaxLength(15);
        }
    }
}
