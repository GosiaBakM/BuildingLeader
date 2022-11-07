
using Microsoft.AspNetCore.Hosting;


namespace BLeader.Data
{
    public class BLeaderSeeder
    {
        //private readonly BLeaderContext _context;
        //private readonly IWebHostEnvironment _environment;

        //public BLeaderSeeder(BLeaderContext context, IWebHostEnvironment environment)
        //{
        //    _context = context;
        //    _environment = environment;
        //}

        public void Seed()
        {
            //_context.Database.EnsureCreated();

            //if (!_context.Products.Any())
            //{
            //    string filePath = Path.Combine(_environment.ContentRootPath, "Data/art.json");
            //    var json = File.ReadAllText(filePath);

            //    IList<Product> products = JsonSerializer.Deserialize<IList<Product>>(json);
            //    _context.Products.AddRange(products);

            //    var order = new Order
            //    {
            //        Id = 1,
            //        Number = "eresdfjiodvn",
            //        Date = DateTime.Now,
            //        Items = new List<OrderItem>
            //        {
            //            new OrderItem
            //            {
            //                Product = products.First(),
            //                UnitPrice = 239,
            //                Quantity = 2
            //            }
            //        }
            //    };

            //    _context.Orders.Add(order);
            //}
            
            //_context.SaveChanges();
        }
    }
}
