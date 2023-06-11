using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IProductServices
    {
        public bool CreatProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);

        public List<Product> GetAllProducts();
      //  public List<Product> GetAllProducts1();
        public Product GetProductById(Guid id);
        public List<Product> GetProductsByName(string name);
    }
}
