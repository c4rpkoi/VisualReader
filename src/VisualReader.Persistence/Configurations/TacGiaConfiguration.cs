using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class TacGiaConfiguration : IEntityTypeConfiguration<TacGia>
    {
        public void Configure(EntityTypeBuilder<TacGia> builder)
        {
            builder.ToTable("TacGia");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.TenTacGia).HasColumnName("TenTacGia");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c => c.TacGiaTruyens).WithOne(c => c.TacGia).HasForeignKey(c => c.TacGiaID);
        }
    }
}