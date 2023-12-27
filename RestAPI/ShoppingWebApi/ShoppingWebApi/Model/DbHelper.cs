using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Model
{
    public class DbHelper
    {
        private Ef_DataContext _DataContext;
        public DbHelper(Ef_DataContext context)
        {
            _DataContext = context;
        }
        //<summary>
        //GET
        //</summary>

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> response = new List<ProductModel>();
            var dataList = _DataContext.Products.ToList();
            //adding product into our product model
            dataList.ForEach(row => response.Add(new ProductModel()
            {
                ProductBrand = row.ProductBrand,
                Id=row.Id,
                ProductName = row.ProductName,
                ProductPrice = row.ProductPrice,
                ProductSize = row.ProductSize,
            })) ;
            return response;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel response = new ProductModel();
            var row = _DataContext.Products.Where(d=>d.Id.Equals(id)).FirstOrDefault();
            return new ProductModel()
            {
                ProductBrand = row.ProductBrand,
                Id = row.Id,
                ProductName = row.ProductName,
                ProductPrice = row.ProductPrice,
                ProductSize = row.ProductSize,

            };
           
        }

        //serves POST/PUT/PATCH

        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();
            if (orderModel.Id > 0)
            {
                //PUT
                dbTable = _DataContext.Orders.Where(d => d.Id.Equals(orderModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.PhoneNumber = orderModel.PhoneNumber;
                    dbTable.Address = orderModel.Address;
                }
            }
                else
                {
                    dbTable.PhoneNumber = orderModel.PhoneNumber;
                    dbTable.Address = orderModel.Address;
                    dbTable.UserName = orderModel.UserName;
                    dbTable.Product = _DataContext.Products.Where(f => f.Id.Equals(orderModel.Product_Id)).FirstOrDefault();
                    _DataContext.Orders.Add(dbTable);
                }

                _DataContext.SaveChanges();

        }

        //<summary>
        //DELETE
        //</summary>
        public void DeleteOrder(int id)
        {
            var order = _DataContext.Orders.Where(d => d.Id.Equals(id)).FirstOrDefault();//used to retrieve the order based on ids
            if(order != null)
            {
                _DataContext.Orders.Remove(order);
                _DataContext.SaveChanges();
            }


        }


    }
}
