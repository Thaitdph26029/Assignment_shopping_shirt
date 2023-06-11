using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(p => p.ID);
            // Set thuộc tính
            builder.Property(p => p.Price).HasColumnType("int");
            builder.Property(c => c.Quantity).HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).
                HasForeignKey(c => c.BillID);
            builder.HasOne(x => x.ProductDetails).WithMany(y => y.BillDetails).
                HasForeignKey(c => c.ProductID);
        }
    }
}
