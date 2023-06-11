using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface ICartDetailService
    {
        public bool CreatCartDetail(CartDetail b);
        public bool UpdateCartDetail(CartDetail b);
        public bool DeleteCartDetail(Guid id);

        public List<CartDetail> GetAllCartDetails();
        public CartDetail GetCartDetailById(Guid id);
        public List<CartDetail> GetCartDetailsByName(string name);
    }
}
