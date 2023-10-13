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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comment");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Content).HasColumnName("content");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.PostId).HasColumnName("post_id");//đặt tên dài thì như thế này
            builder.Property(x => x.ChapterId).HasColumnName("chapter_id");
            builder.Property(x => x.BookId).HasColumnName("book_id");
            builder.Property(x => x.CreatedUtc).HasColumnName("created_utc");
            builder.Property(x => x.UpdatedUtc).HasColumnName("updated_utc");
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Chapter).WithMany(x => x.Comments).HasForeignKey(x => x.ChapterId);
            builder.HasOne(x => x.Posts).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Book).WithMany(x => x.Comments).HasForeignKey(x => x.BookId);

        }
    }
}
