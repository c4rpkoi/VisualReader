using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VisualReader.Application.Services;

namespace VisualReader
{
    public static class ApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApplicationValidator();
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationExtension).GetTypeInfo().Assembly));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            //serviceCollection.AddScoped<IDictionariesService, DictionaryService>();
            serviceCollection.AddScoped<INotificationService, NotificationService>();
            serviceCollection.AddScoped<IUserContext, UserContext>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ICommentService, CommentService>();
            serviceCollection.AddScoped<IBlockService, BlockService>();
            serviceCollection.AddScoped<IBookmarkservice, Bookmarkservice>();
            serviceCollection.AddScoped<IFavoriteListService, FavoriteListService>();
            serviceCollection.AddScoped<IReadingListItemService, ReadingListItemService>();
            serviceCollection.AddScoped<IReadingListService, ReadingListService>();

            serviceCollection.AddScoped<IChapterDataService, ChapterDataService>();
            serviceCollection.AddScoped<IChapterService, ChapterService>();
            serviceCollection.AddScoped<ILoaiTruyenService, LoaiTruyenService>();
            serviceCollection.AddScoped<ILoaiTruyenCuaTruyenService, LoaiTruyenCuaTruyenService>();
            serviceCollection.AddScoped<ITacGiaService, TacGiaService>();
            serviceCollection.AddScoped<ITacGiaTruyenService, TacGiaTruyenService>();
            serviceCollection.AddScoped<ITheLoaiService, TheLoaiService>();
            serviceCollection.AddScoped<ITheLoaiTruyenService, TheLoaiTruyenService>();
            serviceCollection.AddScoped<ITruyenService, TruyenService>();

            serviceCollection.AddSingleton<CacheOptions>(service =>
            {
                var configuration = service.GetRequiredService<IConfiguration>();
                var cacheOptions = new CacheOptions();
                configuration.GetSection("Redis").Bind(cacheOptions);
                return cacheOptions;
            });
            serviceCollection.AddSingleton<ICacheService, CacheService>();
        }

        public static void AddApplicationValidator(this IServiceCollection serviceCollection)
        {
            // All the validator object should be added into DI
            var assemblyType = typeof(ApplicationExtension).GetTypeInfo();
            var validators = assemblyType.Assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract && typeof(IValidator).IsAssignableFrom(x)).ToArray();

            foreach (var validator in validators)
            {
                // Validator is an instance of abstract validator.
                if (validator.BaseType != null && validator.BaseType.IsGenericType && validator.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                {
                    var validatorType =
                        typeof(IValidator<>).MakeGenericType(validator.BaseType.GetGenericArguments()[0]);
                    serviceCollection.AddSingleton(validatorType, validator);
                }
            }
        }
    }
}