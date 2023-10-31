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
    public class TheLoaiConfiguration : IEntityTypeConfiguration<TheLoai>
    {
        public void Configure(EntityTypeBuilder<TheLoai> builder)
        {
            builder.ToTable("TheLoai");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.TenTheLoai).HasColumnName("TenTheLoai");
            builder.Property(c => c.Mota).HasColumnName("Mota");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
            builder.HasMany(c => c.TheLoaiTruyens).WithOne(c => c.TheLoai).HasForeignKey(c => c.TheLoaiID);
        }
    }
}
