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
    public class DsDangDocCongiguration : IEntityTypeConfiguration<DsDangDoc>
    {
        public void Configure(EntityTypeBuilder<DsDangDoc> builder)
        {
            builder.ToTable("dsdangdoc");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.Summary).HasColumnName("summary");

            builder.HasOne(x => x.Users).WithOne(x => x.DsDangDocs).HasForeignKey<DsDangDoc>(x => x.IdUser);
        }
    }
}
