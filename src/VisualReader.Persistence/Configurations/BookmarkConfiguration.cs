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
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable("bookmark");
            builder.Property(x => x.PageInformation).HasColumnName("pageinformation");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");

            builder.HasOne(x => x.Users).WithMany(x => x.Bookmarks).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Chapters).WithMany(x => x.Bookmarks).HasForeignKey(x => x.IdChapter);
        }
    }
}
