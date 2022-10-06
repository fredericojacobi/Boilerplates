using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using Constants;
using Contracts.Repositories;
using Contracts.Services;
using Entities.MapProfiles;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;

namespace Api;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.ConfigureAuthentication();
        services.ConfigureSqlContext(configuration);
        services.ConfigureWrappers();
        services.ConfigureIdentity();
        services.ConfigureSwagger();
        services.ConfigureCors();
        services.ConfigureMapper();
        // services.ConfigureCookies();
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
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.JwtSecret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    private static void ConfigureCookies(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/user/login";
            options.AccessDeniedPath = "";
            options.SlidingExpiration = true;
        });
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
            options.AddPolicy("all",
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
        });
        // Regex.IsMatch(origin, @"^https?:\/\/[a-zA-Z0-9_-]+\.dominio\.com");
    }

    private static void ConfigureMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(config => { config.AddProfile(new UserApplicationProfile()); });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}