using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VisualReader
{
    public class FavorietListContiguration : IEntityTypeConfiguration<FavoriteList>
    {
        public void Configure(EntityTypeBuilder<FavoriteList> builder)
        {
            builder.ToTable("favoritelist");
            builder.Property(x => x.CreateUCT).HasColumnName("created_utc");
            builder.Property(x => x.UpdateUCT).HasColumnName("updated_utc");
            builder.HasOne(x => x.Users).WithMany(x => x.FavoriteLists).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Truyens).WithMany(x => x.FavoriteLists).HasForeignKey(x => x.IdTruyen);
        }
    }
}