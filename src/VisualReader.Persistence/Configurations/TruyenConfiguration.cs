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
    public class TruyenConfiguration : IEntityTypeConfiguration<Truyen>
    {
        public void Configure(EntityTypeBuilder<Truyen> builder)
        {
            builder.ToTable("Truyen");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.TenTruyen).HasColumnName("TenTruyen");
            builder.Property(c => c.AnhBia).HasColumnName("AnhBia");
            builder.Property(c => c.AgeRatting).HasColumnName("AgeRatting");
            builder.Property(c => c.TinhTrang).HasColumnName("TinhTrang");
            builder.Property(c => c.LuotXem).HasColumnName("LuotXem");
            builder.Property(c => c.LuotDanhGia).HasColumnName("LuotDanhGia");
            builder.Property(c => c.SoLuongTheoDoi).HasColumnName("SoLuongTheoDoi");
            builder.Property(c => c.XepHang).HasColumnName("XepHang");
            builder.Property(c => c.NoiDung).HasColumnName("NoiDung");
            builder.Property(c => c.TrangThai).HasColumnName("TrangThai");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c=>c.LoaiTruyenCuaTruyens).WithOne(c=>c.Truyen).HasForeignKey(c=>c.TruyenID);
            builder.HasMany(c=>c.TacGiaTruyens).WithOne(c=>c.Truyen).HasForeignKey(c=>c.TruyenID);
            builder.HasMany(c=>c.TheLoaiTruyens).WithOne(c=>c.Truyen).HasForeignKey(c=>c.TruyenID);
        }
    }
}
