using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class SupplierService : ISupplierService
    {
        ShopDbContext context;
        public SupplierService()
        {
            context = new ShopDbContext();
        }
        public bool CreatSupplier(Supplier r)
        {
            try
            {
                context.Suppliers.Add(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSupplier(Guid id)
        {
            try
            {
                var Suppliers = context.Suppliers.Find(id);
                context.Suppliers.Remove(Suppliers);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            return context.Suppliers.ToList();
        }

        public Supplier GetSupplierById(Guid id)
        {
            return context.Suppliers.FirstOrDefault(p => p.ID == id);
        }

        public List<Supplier> GetSuppliersByName(string name)
        {
            return context.Suppliers.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateSupplier(Supplier r)
        {
            try
            {
                var Suppliers = context.Suppliers.Find(r.ID);

                Suppliers.Name = r.Name;
                Suppliers.Address = r.Address;
                Suppliers.Status = r.Status;



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
