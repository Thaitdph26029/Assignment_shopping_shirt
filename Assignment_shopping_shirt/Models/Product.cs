namespace Assignment_shopping_shirt.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
       
        public int Status { get; set; }       
        public string Description { get; set; }
       
       

        public virtual List<ProductDetails> ProductDetails { get; set; }
    }
}
