using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
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