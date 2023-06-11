using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IUserService
    {
        public bool CreatUser(User u);
        public bool UpdateUser(User u);
        public bool DeleteUser(Guid id);

        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUsersByName(string name);
    }
}
