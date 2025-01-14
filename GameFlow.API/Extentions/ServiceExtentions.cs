using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.IdentityModel.Tokens;
using MediatR;
using GameFlow.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GameFlow.Application.Queries;
using GameFlow.Application.Commands;

namespace GameFlow.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "YourSuperSecretKey");
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"] ?? "GameFlowIssuer",
                ValidAudience = configuration["Jwt:Audience"] ?? "GameFlowAudience",
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GameFlowDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration["Redis:Connection"] ?? "localhost:6379";
        });
        return services;
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtAuthentication(configuration)
                .AddDatabase(configuration)
                .AddRedisCache(configuration);

        // Corrigir a chamada AddMediatR para usar a sobrecarga correta
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            Assembly.GetExecutingAssembly(), // Assembly atual
            typeof(CreateGameCommand).Assembly // Assembly onde os handlers estão definidos
        ));

        // Registrar IGameRepository com sua implementação
        services.AddTransient<IGameRepository, GameRepository>();

        return services;
    }
}
