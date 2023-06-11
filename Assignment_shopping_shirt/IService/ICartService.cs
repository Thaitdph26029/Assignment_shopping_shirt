using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface ICartService
    {
        public bool CreatCart(Cart c);
        public bool UpdateCart(Cart c);
        public bool DeleteCart(Guid id);

        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartsByName(string name);
    }
}
