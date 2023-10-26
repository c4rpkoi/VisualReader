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
    public class ReadingListItemCongiguration : IEntityTypeConfiguration<ReadingLsistItem>
    {
        public void Configure(EntityTypeBuilder<ReadingLsistItem> builder)
        {
            builder.ToTable("dsdadoc");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.ReagingIndex).HasColumnName("chapter");
        }
    }
}
