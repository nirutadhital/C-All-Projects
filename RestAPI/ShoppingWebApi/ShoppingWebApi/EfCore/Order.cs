using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    [Table("Order")]
    public class Order
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }=string.Empty;



    }
}
