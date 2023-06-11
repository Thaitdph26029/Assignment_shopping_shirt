using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IBillService
    {
        public bool CreatBill(Bill b);
        public bool UpdateBill(Bill b);
        public bool DeleteBill(Guid id);

        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
        public List<Bill> GetBillsByName(string name);
    }
}
