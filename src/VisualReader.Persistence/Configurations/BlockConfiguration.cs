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
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("block");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");

            builder.HasOne(x => x.Users).WithMany(x => x.Blocks).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Truyens).WithMany(x => x.Blocks).HasForeignKey(x => x.IdTruyen);
        }
    }
}
