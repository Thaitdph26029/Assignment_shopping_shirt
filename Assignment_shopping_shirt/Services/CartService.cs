using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class CartService : ICartService
    {
        ShopDbContext context;
        public CartService()
        {
            context = new ShopDbContext();
        }
        public bool CreatCart(Cart c)
        {
            try
            {
                context.Carts.Add(c);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var cart = context.Carts.Find(id);
                context.Carts.Remove(cart);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cart> GetAllCarts()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(p => p.UserId == id);
        }

        public List<Cart> GetCartsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart c)
        {
            try
            {
                var cart = context.Carts.Find(c.UserId);

                cart.Description = c.Description;



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
