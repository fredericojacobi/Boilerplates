using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.MapProfiles;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;

namespace Api;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureSqlContext(configuration);
        services.ConfigureWrappers();
        services.AddControllers();
        services.ConfigureIdentity();
        services.ConfigureSwagger();
        services.ConfigureCors();
        services.AddEndpointsApiExplorer();
        services.ConfigureMapper();
    }

    private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetSection("ConnectionString:Database").Value;
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
    }

    private static void ConfigureWrappers(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
    }

    private static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserApplication, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "",
                Title = "",
                Description = "",
                Contact = new OpenApiContact
                {
                    Email = ""
                }
            });
        });
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "corsPolicy",
                builder => { builder.WithOrigins("*"); });
        });
    }
    
    private static void ConfigureMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile(new UserApplicationProfile());
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}