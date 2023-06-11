using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IProductDetailsService
    {
        public bool CreatProductDetails(ProductDetails p);
        public bool UpdateProductDetails(ProductDetails p);
        public bool DeleteProductDetails(Guid id);

        public List<ProductDetails> GetAllProductDetailss();
        //  public List<Product> GetAllProducts1();
        public ProductDetails GetProductDetailsById(Guid id);
        public List<ProductDetails> GetProductDetailsByName(string name);
    }
}
