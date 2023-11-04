using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class TacGiaTruyenConfiguration : IEntityTypeConfiguration<TacGiaTruyen>
    {
        public void Configure(EntityTypeBuilder<TacGiaTruyen> builder)
        {
            builder.ToTable("TacGiaTruyen");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TacGiaID).HasColumnName("TacGiaID");
            builder.Property(c => c.TruyenID).HasColumnName("TruyenID");
            builder.Property(c => c.CreatedUtc).HasColumnName("CreatedUtc");
            builder.Property(c => c.UpdatedUtc).HasColumnName("UpdatedUtc");
        }
    }
}