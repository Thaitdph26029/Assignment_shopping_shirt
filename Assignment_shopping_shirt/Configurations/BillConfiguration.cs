using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasColumnType("Datetime").
                IsRequired(); 
            builder.Property(x => x.Status).HasColumnType("int").
                IsRequired();
        }
    }
}
