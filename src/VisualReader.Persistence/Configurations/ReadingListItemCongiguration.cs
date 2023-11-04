using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class ReadingListItemCongiguration : IEntityTypeConfiguration<ReadingListItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ReadingListItem> builder)
        {
            builder.ToTable("readinglistitem");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.Property(x => x.PageIndex).HasColumnName("pageindex");
        }
    }
}