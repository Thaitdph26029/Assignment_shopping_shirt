using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class BillService : IBillService
    {
        ShopDbContext context;
        public BillService()
        {
            context = new ShopDbContext();
        }
        public bool CreatBill(Bill b)
        {
            try
            {
                context.Bills.Add(b);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = context.Bills.Find(id);
                context.Bills.Remove(bill);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBills()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(p => p.Id == id);
        }

        public List<Bill> GetBillsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBill(Bill b)
        {
            try
            {
                var product = context.Bills.Find(b.Id);

                product.CreateDate = b.CreateDate;
                product.UserID = b.UserID;
                product.Status = b.Status;
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
