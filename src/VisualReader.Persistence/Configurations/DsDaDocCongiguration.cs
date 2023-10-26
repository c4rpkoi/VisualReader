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
    public class DsDaDocCongiguration : IEntityTypeConfiguration<DsDaDoc>
    {
        public void Configure(EntityTypeBuilder<DsDaDoc> builder)
        {
            builder.ToTable("dsdadoc");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.Chapter).HasColumnName("chapter");
        }
    }
}
