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
    public class LoaiTruyenConfiguration : IEntityTypeConfiguration<LoaiTruyen>
    {
        public void Configure(EntityTypeBuilder<LoaiTruyen> builder)
        {
            builder.ToTable("LoaiTruyen");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.TenTheLoai).HasColumnName("TenTheLoai");
            builder.Property(c => c.Mota).HasColumnName("Mota");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c => c.LoaiTruyenCuaTruyens).WithOne(c => c.LoaiTruyen).HasForeignKey(c => c.LoaiTruyenID);
        }
    }
}
