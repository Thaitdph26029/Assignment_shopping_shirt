using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class SizeService : ISizeService
    {
        ShopDbContext context;
        public SizeService()
        {
            context = new ShopDbContext();
        }
        public bool CreatSize(Size r)
        {
            try
            {
                context.Sizes.Add(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var size = context.Sizes.Find(id);
                context.Sizes.Remove(size);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Size> GetAllSizes()
        {
            return context.Sizes.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return context.Sizes.FirstOrDefault(p => p.ID == id);
        }

        public List<Size> GetSizesByName(string name)
        {
            return context.Sizes.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateSize(Size r)
        {
            try
            {
                var size = context.Sizes.Find(r.ID);

                size.Name = r.Name;
                size.Lenght = r.Lenght;
                size.Width = r.Width;
                size.Status = r.Status;



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
