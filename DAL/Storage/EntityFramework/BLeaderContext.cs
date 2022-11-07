using DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Storage.EntityFramework
{
    public class BLeaderContext : DbContext
    {
        private readonly IConfiguration _config;


        //przekazana konfiguracja a  nie tylko connection string
        public BLeaderContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //move somewhere else???

            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config.GetConnectionString("BLeaderContextDb"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.Number)
            //    .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .IsUnicode(false);

            //modelBuilder.Entity<Order>()
            //    .HasData(new Order
            //    {
            //        Id = 1,
            //        Number = "eresdfjiodvn",
            //        Date = DateTime.Now,
            //        //Items = new List<OrderItem>
            //        //{
            //        //    new OrderItem
            //        //    {
            //        //        UnitPrice = 239,
            //        //        Quantity = 2
            //        //    }
            //        //}
            //    });
        }
    }
}
