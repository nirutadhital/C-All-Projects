using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    [Table("Product")]
    public class Product
    {
        [Key,Required]
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductBrand { get; set; }= string.Empty;
        public string ProductSize { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }

    }
}
