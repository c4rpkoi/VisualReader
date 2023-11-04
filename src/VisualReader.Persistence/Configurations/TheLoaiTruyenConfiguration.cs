using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class TheLoaiTruyenConfiguration : IEntityTypeConfiguration<TheLoaiTruyen>
    {
        public void Configure(EntityTypeBuilder<TheLoaiTruyen> builder)
        {
            builder.ToTable("TheLoaiTruyen");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.TheLoaiID).HasColumnName("TheLoaiID");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}