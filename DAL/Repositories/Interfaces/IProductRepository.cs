using System.Collections.Generic;
using DAL.Data.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();
        bool SaveChanges();
    }
}