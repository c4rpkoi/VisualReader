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
        public DbSet<BaiViet> BaiViets { get; set; }

        public VisualReaderDbContext(DbContextOptions<VisualReaderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EnglishToVietNameseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new BaiVietConfiguration());
        }
    }
}