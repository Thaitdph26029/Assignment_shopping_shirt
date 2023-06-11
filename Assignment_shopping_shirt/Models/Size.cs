namespace Assignment_shopping_shirt.Models
{
    public class Size
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }

       // public virtual List<Product> Products { get; set; }
        public virtual List<ProductDetails> ProductDetails { get; set; }
    }
}
