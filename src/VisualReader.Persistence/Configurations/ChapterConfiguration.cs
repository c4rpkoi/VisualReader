using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Persistence.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapter");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.LoaiTruyenCuaTruyenID).HasColumnName("LoaiTruyenCuaTruyenID");
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.NgayDang).HasColumnName("NgayDang");
            builder.Property(c => c.LuotXem).HasColumnName("LuotXem");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasOne(x => x.ChapterData).WithOne(x => x.Chapter).HasForeignKey<ChapterData>(x => x.ChapterID);

        }

    }
}
