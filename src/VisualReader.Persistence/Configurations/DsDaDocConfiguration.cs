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
    public class DsDaDocConfiguration : IEntityTypeConfiguration<DsDaDoc>
    {
        public void Configure(EntityTypeBuilder<DsDaDoc> builder)
        {
            builder.ToTable("dsdadoc");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.Chapter).HasColumnName("chapter");

            builder.HasOne(x => x.DsDangDocs).WithMany(x => x.DsDaDocs).HasForeignKey(x => x.IdDsDangDoc);
            builder.HasOne(x => x.Truyens).WithMany(x => x.DsDaDocs).HasForeignKey(x => x.IdTruyen);
        }
    }
}
