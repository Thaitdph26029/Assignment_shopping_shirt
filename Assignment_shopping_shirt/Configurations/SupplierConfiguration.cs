using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Address).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Status).HasColumnType("int");
        }
    }
}
