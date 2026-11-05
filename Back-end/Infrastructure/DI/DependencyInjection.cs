using Application.Interfaces;
using Domain.Repositories;
using Infrastructure.DB.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        }

        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtGenerator._jwtK)),
                    ClockSkew = TimeSpan.Zero
                };

                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["JCook"];

                        return Task.CompletedTask;
                    }
                };

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy
                    .RequireRole("Admin")
                    .RequireAssertion(context =>
                        context.User.HasClaim(c => c.Type == "isBlocked" && c.Value == "false"))
                );

                options.AddPolicy("ProFunctions", policy => policy
                    .RequireRole("Admin", "ProUser")
                    .RequireAssertion(context => context.User.HasClaim(c => c.Type == "isBlocked" && c.Value.ToLower() == "false"))
                );

                options.AddPolicy("StandartFunctions", policy => policy
                    .RequireRole("Admin", "ProUser", "User")
                    .RequireAssertion(context => context.User.HasClaim(c => c.Type == "isBlocked" && c.Value == "false"))
                );
            });

            return services;
        }
    }
}
