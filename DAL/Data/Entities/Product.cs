using DAL.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data.Entities
{
    //[Table("Products")]
    public class Product
    {
        //[Key]
        //[Column("cit_id")]
        public int Id { get; set; }

        //[Column]
        public ProductCategory Category { get; set; }

        //[StringLength(50)]
        //[Column("cit_name")]
        public string Name { get; set; }

        public decimal Price { get; set; }
        //Add some more data 
    }
}
