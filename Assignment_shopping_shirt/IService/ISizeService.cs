using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface ISizeService
    {
        public bool CreatSize(Size r);
        public bool UpdateSize(Size r);
        public bool DeleteSize(Guid id);

        public List<Size> GetAllSizes();
        public Size GetSizeById(Guid id);
        public List<Size> GetSizesByName(string name);
    }
}
