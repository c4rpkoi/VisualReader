using Microsoft.EntityFrameworkCore;
using VisualReader.Domain.Entities;
using VisualReader.Persistence.Configurations;

namespace VisualReader.Persistence.Context
{
    public class VisualReaderDbContext : DbContext
    {
        //public DbSet<EnglishToVietNamese> EnglishToVietNameses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<FavoriteList>  FavoriteLists { get; set; }
        public DbSet<ReadingList>  ReadingLists { get; set; }
        public DbSet<ReadingLsistItem>  ReadingLsistItems { get; set; }
        public VisualReaderDbContext(DbContextOptions<VisualReaderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EnglishToVietNameseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new BlockConfiguration());
            modelBuilder.ApplyConfiguration(new BookmarkConfiguration());
            modelBuilder.ApplyConfiguration(new ReadingListCongiguration());
            modelBuilder.ApplyConfiguration(new ReadingListItemCongiguration());
            modelBuilder.ApplyConfiguration(new FavorietListContiguration());
        }
    }
}