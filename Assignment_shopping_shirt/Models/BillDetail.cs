namespace Assignment_shopping_shirt.Models
{
    public class BillDetail
    {
        public Guid ID { get; set; }
        public Guid BillID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
