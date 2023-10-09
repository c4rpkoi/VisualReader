using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Persistence.Configurations
{
    public class TheLoaiTruyenConfiguration : IEntityTypeConfiguration<TheLoaiTruyen>
    {
        public void Configure(EntityTypeBuilder<TheLoaiTruyen> builder)
        {
            builder.ToTable("TheLoaiTruyen");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.TheLoaiID).HasColumnName("TheLoaiID");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}
