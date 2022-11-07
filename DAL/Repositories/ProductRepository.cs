using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Data.Entities;
using DAL.Repositories.Interfaces;
using DAL.Storage.EntityFramework;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BLeaderContext _context;
        private readonly ILogger<IProductRepository> _logger;

        public ProductRepository(
            BLeaderContext context,
            ILogger<IProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Log get All products");
                return _context.Products.OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to {nameof(GetAllProducts)} with {ex}");
                return null;
            }

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        //IList<Product> IProductRepository.GetAllProducts()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
