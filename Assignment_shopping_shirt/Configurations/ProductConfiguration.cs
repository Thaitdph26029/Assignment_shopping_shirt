using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).IsUnicode(true).
                HasMaxLength(100).IsFixedLength();
            // 2 cái trên tương đương nhau nhé =))
           

        }
    }
}
