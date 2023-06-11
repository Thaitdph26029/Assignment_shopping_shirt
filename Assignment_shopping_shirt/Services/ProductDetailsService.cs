using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Services
{
    public class ProductDetailsService: IProductDetailsService
    {
        ShopDbContext context;      
        public ProductDetailsService()
        {
            context = new ShopDbContext();
        }

        public bool CreatProductDetails(ProductDetails p)
        {

            try
            {
                context.ProductDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProductDetails(Guid id)
        {
            try
            {
                var product = context.ProductDetails.Find(id);
                context.ProductDetails.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductDetails> GetAllProductDetailss()
        {
            return context.ProductDetails.ToList();
        }

        public ProductDetails GetProductDetailsById(Guid id)
        {
            return context.ProductDetails.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductDetails> GetProductDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductDetails(ProductDetails p)
        {
           


            try
            {
                var ProductDetails = context.ProductDetails.Find(p.Id);

                ProductDetails.SizeID = p.SizeID;
                ProductDetails.SupplierID = p.SupplierID;
                ProductDetails.ColorID = p.ColorID;
                ProductDetails.AvailableQuantity = p.AvailableQuantity;



                // context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
