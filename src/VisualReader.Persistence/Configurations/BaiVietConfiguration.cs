using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{ 
    public class BaiVietConfiguration : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.ToTable("baiviet");
            builder.Property(x => x.TieuDe).HasColumnName("tieude");
            builder.Property(x => x.MoTa).HasColumnName("mo_a");
            builder.Property(x => x.Anh).HasColumnName("anh");
            builder.Property(x => x.ThoiGianDang).HasColumnName("thoigiandang");

        }

    }
}
