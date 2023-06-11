using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class ColorService : IColorService
    {
        ShopDbContext context;
        public ColorService()
        {
            context = new ShopDbContext();
        }
        public bool CreatColor(Color c)
        {
            try
            {
                context.Colors.Add(c);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var color = context.Colors.Find(id);
                context.Colors.Remove(color);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Color> GetAllColors()
        {
            return context.Colors.ToList();
        }

        public Color GetColorById(Guid id)
        {
            return context.Colors.FirstOrDefault(u => u.ID == id);
        }

        public List<Color> GetColorsByName(string name)
        {
            return context.Colors.Where(u => u.Name.Contains(name)).ToList();
        }

        public bool UpdateColor(Color c)
        {
            try
            {
                var color = context.Colors.Find(c.ID);
                color.Name = c.Name;
                color.Status = c.Status;              
                // context.Products.Update(user);
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
