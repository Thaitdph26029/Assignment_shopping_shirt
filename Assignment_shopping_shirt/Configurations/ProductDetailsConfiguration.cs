using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class ProductDetailsConfiguration : IEntityTypeConfiguration<ProductDetails>
    {
       

        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Colors).WithMany(p => p.ProductDetails).
                    HasForeignKey(p => p.ColorID);
            builder.HasOne(p => p.Sizes).WithMany(p => p.ProductDetails).
                    HasForeignKey(p => p.SizeID);
            builder.HasOne(p => p.Suppliers).WithMany(p => p.ProductDetails).
                    HasForeignKey(p => p.SupplierID);
            builder.HasOne(x => x.Products).WithMany(y => y.ProductDetails).
             HasForeignKey(c => c.ProductId);
        }
    }
}
