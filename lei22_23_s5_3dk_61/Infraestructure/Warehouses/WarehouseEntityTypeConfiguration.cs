using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Infrastructure.Warehouses
{
    internal class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            //builder.ToTable("Warehouses", SchemaNames.DDDSample1);
          
            builder.HasKey(b =>  b.Id);
            builder.ToTable("Warehouses");
            builder.OwnsOne(b => b.WarehouseIdentifier);
            builder.OwnsOne(b => b.Designation);
            builder.OwnsOne(b => b.Address);
            builder.OwnsOne(b => b.Coordinates);
            builder.OwnsOne(b => b.WarehouseAltitude);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}