using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Data.Configuration
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(t => t.Id); // Identity
            //builder.HasKey(t => new {t.Id, t.Name }); // Composite key
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Name);
            builder.Property(t => t.Region);
            builder.Property(t => t.WarehouseTypeId);

           
            builder
                .HasOne(t => t.WarehouseType)
                .WithMany(t => t.Warehouses)
                .HasForeignKey(t=> t.WarehouseTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            

        }
    }
}
