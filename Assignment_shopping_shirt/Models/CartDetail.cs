namespace Assignment_shopping_shirt.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
