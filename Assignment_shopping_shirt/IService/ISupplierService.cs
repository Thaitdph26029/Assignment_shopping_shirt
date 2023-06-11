using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface ISupplierService
    {
        public bool CreatSupplier(Supplier r);
        public bool UpdateSupplier(Supplier r);
        public bool DeleteSupplier(Guid id);

        public List<Supplier> GetAllSuppliers();
        public Supplier GetSupplierById(Guid id);
        public List<Supplier> GetSuppliersByName(string name);
    }
}
