

using AutoMapper;
using BLeader.Data;
using BLeader.Mapping;
using BLeader.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IProductRepository = DAL.Repositories.Interfaces.IProductRepository;
using ProductRepository = DAL.Repositories.ProductRepository;
using BLeaderContext = DAL.Storage.EntityFramework.BLeaderContext;
using BLL.Services;
using BLL.Services.Interfaces;
using System;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using DAL.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApp.Extensions;
using WebApp.Middleware;

namespace BLeader
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_configuration);
            services.AddControllers();
            services.AddCors();
            services.AddIdentityServices(_configuration);   
            //services.AddControllersWithViews()
            //    .AddRazorRuntimeCompilation();

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            ////change below for some other redirection for production, and maybe add for stage or test
            //else
            //{
            //    app.UseExceptionHandler("/MyError");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            //app.UseHttpsRedirection();
            //to my static files in admin panel
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //    //endpoints.MapControllerRoute("default", "/{controller}/{action}/{id?}",
            //    //    new { controller = "Trial", action = "Index" });
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
