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
    public class LoaiTruyenCuaTruyenConfiguration : IEntityTypeConfiguration<LoaiTruyenCuaTruyen>
    {
        public void Configure(EntityTypeBuilder<LoaiTruyenCuaTruyen> builder)
        {
            builder.ToTable("LoaiTruyenCuaTruyen");
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.LoaiTruyenID).HasColumnName("LoaiTruyenID");
            builder.Property(c=>c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c=>c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c=>c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c => c.Chapters).WithOne(c => c.LoaiTruyenCuaTruyen).HasForeignKey(c => c.LoaiTruyenCuaTruyenID);
        }
    }
}
