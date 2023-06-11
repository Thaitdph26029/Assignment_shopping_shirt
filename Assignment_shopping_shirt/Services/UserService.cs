using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class UserService : IUserService
    {
        ShopDbContext context;
        public UserService()
        {
            context = new ShopDbContext();
        }

        public bool CreatUser(User u)
        {
            try
            {
                context.Users.Add(u);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var user = context.Users.Find(id);
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsersByName(string name)
        {
            return context.Users.Where(u => u.Username.Contains(name)).ToList();
        }

        public bool UpdateUser(User u)
        {
            try
            {
                var user = context.Users.Find(u.Id);

                user.Username = u.Username;
                user.Password = u.Password;
                user.RoleId = u.RoleId;
                user.Status = u.Status;
                user.Email = u.Email;
                user.Phone = u.Phone;
                user.Address= u.Address;

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
