using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class ChapterDataConfiguration : IEntityTypeConfiguration<ChapterData>
    {
        public void Configure(EntityTypeBuilder<ChapterData> builder)
        {
            builder.ToTable("ChapterData");
            builder.HasKey(c => c.Id);
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