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

            serviceCollection.AddScoped<ITruyenManagerRepository, TruyenManagerRepository>();
        }
    }
}