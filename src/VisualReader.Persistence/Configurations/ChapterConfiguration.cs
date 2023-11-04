using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapter");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.UserID).HasColumnName("UserID");
            builder.Property(c => c.LoaiTruyenCuaTruyenID).HasColumnName("LoaiTruyenCuaTruyenID");
            builder.Property(c => c.Title).HasColumnName("Title");
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.NgayDang).HasColumnName("NgayDang");
            builder.Property(c => c.LuotXem).HasColumnName("LuotXem");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasOne(x => x.ChapterData).WithOne(x => x.Chapter).HasForeignKey<ChapterData>(x => x.ChapterID);
        }
    }
}