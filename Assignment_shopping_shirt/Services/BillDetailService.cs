using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class BillDetailService : IBillDetailService
    {
        ShopDbContext context;
        public BillDetailService()
        {
            context = new ShopDbContext();
        }
        public bool CreatBillDetail(BillDetail b)
        {
            try
            {
                context.BillDetails.Add(b);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {

            try
            {
                var billdetail = context.BillDetails.Find(id);
                context.BillDetails.Remove(billdetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return context.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillDetails.FirstOrDefault(b => b.ID == id);
        }

        public List<BillDetail> GetBillDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetail(BillDetail b)
        {
            try
            {
                var billdetail = context.BillDetails.Find(b.ID);

                billdetail.BillID = b.BillID;
                billdetail.ProductID = b.ProductID;
                billdetail.Quantity = b.Quantity;
                billdetail.Price = b.Price;
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
