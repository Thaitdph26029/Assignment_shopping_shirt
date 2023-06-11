using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class CartDetailService : ICartDetailService
    {
        ShopDbContext context;
        public CartDetailService()
        {
            context = new ShopDbContext();
        }
        public bool CreatCartDetail(CartDetail b)
        {
            try
            {
                context.CartDetails.Add(b);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var cartdetail = context.CartDetails.Find(id);
                context.CartDetails.Remove(cartdetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return context.CartDetails.ToList();
        }

        public CartDetail GetCartDetailById(Guid id)
        {
            return context.CartDetails.FirstOrDefault(p => p.Id == id);
        }

        public List<CartDetail> GetCartDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetail(CartDetail b)
        {

            try
            {
                var cartdetail = context.CartDetails.Find(b.Id);

               // cartdetail.UserId = b.UserId;
                //cartdetail.ProductID = b.ProductID;
                cartdetail.Quantity = b.Quantity;
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
