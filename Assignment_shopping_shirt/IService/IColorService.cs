using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IColorService
    {
        public bool CreatColor(Color c);
        public bool UpdateColor(Color c);
        public bool DeleteColor(Guid id);

        public List<Color> GetAllColors();
        public Color GetColorById(Guid id);
        public List<Color> GetColorsByName(string name);
    }
}
