using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using STI.Data.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace STI.Data.Configuration
{
    public class WarehouseTypeConfiguration : IEntityTypeConfiguration<WarehouseType>
    {
        public void Configure(EntityTypeBuilder<WarehouseType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id);
            builder.Property(t => t.Description);
            builder.HasData(Get());

            builder
                .HasMany(t => t.Warehouses)
                .WithOne(t => t.WarehouseType)
                .HasForeignKey(t=> t.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private ICollection<WarehouseType> Get() 
        {
            return new List<WarehouseType>()
            {
                new WarehouseType(){ Id = 1, Description = "Almacen Tipo 1" },
                new WarehouseType(){ Id = 2, Description = "Almacen Tipo 2" }
            };
        }
    }
}
