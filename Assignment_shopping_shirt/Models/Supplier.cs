namespace Assignment_shopping_shirt.Models
{
    public class Supplier
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }      
        //public virtual List<Product> Products { get; set; }
        public virtual List<ProductDetails> ProductDetails { get; set; }
    }
}
