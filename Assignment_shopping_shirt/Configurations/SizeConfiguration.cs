using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.ID);      
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.Lenght).HasColumnType("decimal(5,3)").IsRequired();
            builder.Property(p => p.Width).HasColumnType("decimal(5,3)").IsRequired();
            builder.Property(p => p.Status).HasColumnType("int").IsRequired();

        }
    }
}
