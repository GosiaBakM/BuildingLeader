using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using BLeader.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using DAL.Storage.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DAL.Seed;
using System;
using Microsoft.Extensions.Logging;

namespace BLeader
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //if (args.Length == 1 && args[0].ToLower() == "/seed")
            //{
                //RunSeeding(host);

                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;

                try
                {
                    var contex = services.GetRequiredService<BLeaderContext>();
                    await contex.Database.MigrateAsync();
                    await Seed.SeedUsers(contex);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }

                await host.RunAsync();
            //}
            //else
            //{
            //    host.Run();
            //}

        }

        //private static void RunSeeding(IHost host)
        //{
        //    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var seeder = scope.ServiceProvider.GetService<BLeaderSeeder>();
        //        seeder.Seed();
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            var path = Directory.GetCurrentDirectory();
            builder.Sources.Clear();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

        }
    }
}
