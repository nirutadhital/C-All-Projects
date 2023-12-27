using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }

        //public virtual Product Product { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
