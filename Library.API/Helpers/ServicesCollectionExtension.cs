using Library.API.Core.Interfaces;
using Library.API.Data;
using Library.API.Data.Repositories;
using Library.API.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Helpers
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookshelfRepository, BookshelfRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookAuthorService, BookAuthorService>();
            return services;
        }
    }
}