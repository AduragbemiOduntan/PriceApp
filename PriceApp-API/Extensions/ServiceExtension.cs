using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PriceApp_Application.Services.Implementation;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.UOW;

namespace PriceApp_API.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMaterialEstimateService, MaterialEstimateService>();
         /*   services.AddScoped<ISettingOutStageService, SettingOutStageService>();*/

        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DataBaseContext>()
            .AddDefaultTokenProviders();
        }
    }
}
