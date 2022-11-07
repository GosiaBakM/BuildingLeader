using BLeader.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLeaderContext = DAL.Storage.EntityFramework.BLeaderContext;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using BLL.Services.Interfaces;
using BLL.Services;
using System;
using BLeader.Mapping;
using BLL.Mapping;

namespace WebApp.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IRepository, EFBaseRepository>();
            //services.AddScoped<IRepository<User>, EFBaseRepository<User>>();

            services.AddDbContext<BLeaderContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BLeaderContextDb"));
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(typeof(WebbAppProfile).Assembly, typeof(BllProfile).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
