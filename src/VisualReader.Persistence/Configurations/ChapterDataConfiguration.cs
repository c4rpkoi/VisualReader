using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Persistence.Configurations
{
    public class ChapterDataConfiguration : IEntityTypeConfiguration<ChapterData>
    {
        public void Configure(EntityTypeBuilder<ChapterData> builder)
        {
            builder.ToTable("ChapterData");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Ma).HasColumnName("Ma");
            builder.Property(c => c.STT).HasColumnName("STT");
            builder.Property(c => c.ChapterID).HasColumnName("ChapterID");
            builder.Property(c => c.Data).HasColumnName("Data");
            builder.Property(c => c.DataType).HasColumnName("DataType");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}
