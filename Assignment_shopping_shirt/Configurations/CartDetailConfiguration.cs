using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cart).WithMany(p => p.CartDetails).
                HasForeignKey(x => x.UserId).HasConstraintName("FK_Cart");
            builder.HasOne(x => x.ProductDetails).WithMany(p => p.CartDetails).
                HasForeignKey(x => x.ProductID).HasConstraintName("FK_Product");
        }
    }
}
