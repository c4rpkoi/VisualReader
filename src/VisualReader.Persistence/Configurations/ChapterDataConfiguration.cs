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
            builder.Property(c => c.ChapterID).HasColumnName("ChapterID");
            builder.Property(c => c.DataText).HasColumnName("DataText");
            builder.Property(c => c.DataImg).HasColumnName("DataImg");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}
