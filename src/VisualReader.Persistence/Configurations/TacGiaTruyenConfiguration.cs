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
    public class TacGiaTruyenConfiguration : IEntityTypeConfiguration<TacGiaTruyen>
    {
        public void Configure(EntityTypeBuilder<TacGiaTruyen> builder)
        {
            builder.ToTable("TacGiaTruyen");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.TacGiaID).HasColumnName("TacGiaID");
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}
