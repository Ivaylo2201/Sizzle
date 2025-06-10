using System.Security.Claims;
using Application.Interfaces.Services;
using Core.Interfaces.Repositories;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public record JwtConfig(byte[] Key, string Issuer, string Audience);

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, JwtConfig jwtConfig, string connectionString)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddSingleton<ITokenService, TokenService>();

        services.AddDbContext<DatabaseContext>(d =>
        {
            d.UseSqlServer(connectionString,
                s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });
        
        services.AddJwtAuthentication(jwtConfig.Key, jwtConfig.Issuer, jwtConfig.Audience);
        services.AddCorsSupport();
    }

    private static void AddJwtAuthentication(this IServiceCollection services, byte[] key, string issuer, string audience)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        
        services.AddAuthorization();
    }

    private static void AddCorsSupport(this IServiceCollection services)
    {
        services.AddCors(o =>
        {
            o.AddPolicy(
                "AllowFrontend", 
                p => p.WithOrigins("http://localhost:5173/").AllowAnyHeader().AllowAnyMethod());

            o.AddPolicy(
                "AllowAny", 
                p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }
}