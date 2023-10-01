using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisualReader.Domain.Entities;

namespace VisualReader.Persistence.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("user_details");
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number");
            builder.Property(x => x.FirstName).HasColumnName("first_name");
            builder.Property(x => x.MiddleName).HasColumnName("middle_name");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.Address).HasColumnName("address");
            builder.Property(x => x.Avatar).HasColumnName("avatar");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.HasOne(x => x.User).WithOne(x => x.UserDetail).HasForeignKey<UserDetail>(x => x.UserId);
        }
    }
}