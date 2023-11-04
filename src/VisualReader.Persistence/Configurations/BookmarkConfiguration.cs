using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable("bookmark");
            builder.Property(x => x.PageIndex).HasColumnName("pageindex");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.HasOne(x => x.Users).WithMany(x => x.Bookmarks).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Chapters).WithMany(x => x.Bookmarks).HasForeignKey(x => x.IdChapter);
        }
    }
}