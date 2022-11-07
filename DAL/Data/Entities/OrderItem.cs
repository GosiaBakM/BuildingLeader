using System.Diagnostics.CodeAnalysis;

namespace DAL.Data.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        //[SuppressMessage(..., ...]
        public Order Order { get; set; }

    }
}
