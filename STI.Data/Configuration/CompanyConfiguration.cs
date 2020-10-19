using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STI.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.WarehouseId);

            builder
                .HasOne(t => t.Warehouse)
                .WithOne(t => t.Company)
                .OnDelete(DeleteBehavior.NoAction);
    
        }
    }
}
