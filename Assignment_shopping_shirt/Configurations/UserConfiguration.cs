using Assignment_shopping_shirt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_shopping_shirt.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("nchar(256)");
            builder.Property(x => x.Password).HasColumnType("nchar(256)");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p => p.RoleId);
        }
    }
}
