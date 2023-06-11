namespace Assignment_shopping_shirt.Models
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
        public Guid SizeID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid ColorID { get; set; }
        public Guid ProductId { get; set; }
        public int AvailableQuantity { get; set; }
        public virtual Color Colors { get; set; }
        public virtual Size Sizes { get; set; }

        public virtual Supplier Suppliers { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }
        public virtual Product Products { get; set; }
    }
}
