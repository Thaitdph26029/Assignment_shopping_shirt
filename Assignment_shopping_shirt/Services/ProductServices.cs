using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class ProductServices : IProductServices
    {
        ShopDbContext context;
        public ProductServices()
        {
            context = new ShopDbContext();
        }

        public bool CreatProduct(Product p)
        {
            try
            {
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.Where(x => x.Status < 3).ToList();
        }
        //public List<Product> GetAllProducts1()
        //{
        //    var lst = from a in context.Products
        //              join b in context.Colors on a.ColorID equals b.ID
        //              join c in context.Sizes on a.SizeID equals c.ID
        //              join d in context.Suppliers on a.SupplierID equals d.ID
        //              where a.AvailableQuantity >0
        //              select new Product
        //              {
        //                  Id= a.Id,
        //                  ColorID = b.Name,

        //              }
        //}

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByName(string name)
        {
            return context.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.Id);


                product.Image = p.Image;
                product.Name = p.Name;
                product.Description = p.Description;
                product.Price = p.Price;
                //product.AvailableQuantity = p.AvailableQuantity;
                //product.Suppliers = p.Suppliers;
                //product.ColorID = p.ColorID;
                //product.SizeID = p.SizeID;
                product.Status = p.Status;


                context.Products.Update(product);
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
