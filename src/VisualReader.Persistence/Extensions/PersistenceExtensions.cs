using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VisualReader.Application.Repositories;
using VisualReader.Persistence.Context;
using VisualReader.Persistence.Repositories;

namespace VisualReader.Persistence.Extension
{
    public static class PersistenceExtensions
    {
        public static void AddPersistenceService(this IServiceCollection serviceCollection, bool isDevelopment = true)
        {
            serviceCollection.AddDbContext<VisualReaderDbContext>((service, option) =>
            {
                var configuration = service.GetService<IConfiguration>();
                var connectionString = configuration["ConnectionStrings:Default"];
                option.UseSqlServer(connectionString);
            });

            serviceCollection.AddMemoryCache();
            
            //serviceCollection.AddScoped<IDictionaryRepository, DictionaryRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

<<<<<<< HEAD

            serviceCollection.AddScoped<IBookmarkRepository, BookmarkRepository>();
            serviceCollection.AddScoped<IBlockRepository, BlockRepository>();
            serviceCollection.AddScoped<IFavoriteListRepository, FavoriteListRepository>();
            serviceCollection.AddScoped<IReadingListRepository, ReadingListRepository>();
            serviceCollection.AddScoped<IReadingListItemRepository, ReadingListItemRepository>();

=======
            serviceCollection.AddScoped<IChapterDataRepository, ChapterDataRepository>();
            serviceCollection.AddScoped<IChapterRepository, ChapterRepositoty>();
            serviceCollection.AddScoped<ILoaiTruyenRepository, LoaiTruyenRepository>();
            serviceCollection.AddScoped<ILoaiTruyenCuaTruyenRepository, LoaiTruyenCuaTruyenRepository>();
            serviceCollection.AddScoped<ITacGiaRepository, TacGiaRepository>();
            serviceCollection.AddScoped<ITacGiaTruyenRepository, TacGiaTruyenRepository>();
            serviceCollection.AddScoped<ITheLoaiRepository, TheLoaiRepository>();
            serviceCollection.AddScoped<ITheLoaiTruyenRepository, TheLoaiTruyenRepository>();
            serviceCollection.AddScoped<ITruyenRepository, TruyenRepository>();
>>>>>>> 6bd954113ba0624ff4fd00e950e03e63a255f3bf
        }
    }
}