using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class ReadingListCongiguration : IEntityTypeConfiguration<ReadingList>
    {
        public void Configure(EntityTypeBuilder<ReadingList> builder)
        {
            builder.ToTable("readinglist");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.HasOne(x => x.Users).WithOne(x => x.ReadingLists).HasForeignKey<ReadingList>(x => x.IdUser);
        }
    }
}