using Application.Interfaces;
using Domain.Repositories;
using Infrastructure.DB.Repository;
using Infrastructure.DB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Security;

namespace Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserActionRepository, UserActionRepository>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
