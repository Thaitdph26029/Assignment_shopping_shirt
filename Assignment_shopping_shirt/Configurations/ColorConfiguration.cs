using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            
        }
    }
}
