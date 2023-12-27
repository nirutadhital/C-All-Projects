namespace ShoppingWebApi.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductBrand { get; set; } = string.Empty;
        public string ProductSize { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
    }
}
