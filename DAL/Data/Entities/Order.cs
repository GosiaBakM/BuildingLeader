using System;
using System.Collections.Generic;

namespace DAL.Data.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}
