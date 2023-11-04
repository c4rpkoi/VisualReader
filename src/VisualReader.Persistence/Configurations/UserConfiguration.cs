using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.UserTypeCode).HasColumnName("user_type_code");
            builder.Property(x => x.Role).HasColumnName("role");
            builder.Property(x => x.CreatedUtc).HasColumnName("created_utc");
            builder.Property(x => x.UpdatedUtc).HasColumnName("updated_utc");
            builder.Property(x => x.Verified).HasColumnName("verified");
            builder.Property(x => x.Locked).HasColumnName("locked");
            builder.Property(x => x.Deleted).HasColumnName("deleted");
        }
    }
}