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
    public class DsQuanTamContiguration : IEntityTypeConfiguration<DsQuanTam>
    {
        void IEntityTypeConfiguration<DsQuanTam>.Configure(EntityTypeBuilder<DsQuanTam> builder)
        {
            builder.ToTable("dsquantam");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.LoaiQuanTam).HasColumnName("loaiquantam");

            builder.HasOne(x => x.Users).WithMany(x => x.DsQuanTams).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Truyens).WithMany(x => x.DsQuanTams).HasForeignKey(x => x.IdTruyen);
        }
    }
    }
}
