using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IBillDetailService
    {
        public bool CreatBillDetail(BillDetail b);
        public bool UpdateBillDetail(BillDetail b);
        public bool DeleteBillDetail(Guid id);

        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);
        public List<BillDetail> GetBillDetailsByName(string name);
    }
}
