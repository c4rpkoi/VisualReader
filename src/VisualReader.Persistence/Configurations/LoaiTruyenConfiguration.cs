using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class LoaiTruyenConfiguration : IEntityTypeConfiguration<LoaiTruyen>
    {
        public void Configure(EntityTypeBuilder<LoaiTruyen> builder)
        {
            builder.ToTable("LoaiTruyen");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.TenTheLoai).HasColumnName("TenTheLoai");
            builder.Property(c => c.Mota).HasColumnName("Mota");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c => c.LoaiTruyenCuaTruyens).WithOne(c => c.LoaiTruyen).HasForeignKey(c => c.LoaiTruyenID);
        }
    }
}