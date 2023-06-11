using Assignment_shopping_shirt.IService;
using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.Service
{
    public class RoleService : IRoleService
    {
        ShopDbContext context;
        public RoleService()
        {
            context = new ShopDbContext();
        }
        public bool CreatRole(Role r)
        {
            try
            {
                context.Roles.Add(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var Role = context.Roles.Find(id);
                context.Roles.Remove(Role);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(p => p.Id == id);
        }

        public List<Role> GetRolesByName(string name)
        {
            return context.Roles.Where(p => p.RoleName.Contains(name)).ToList();
        }

        public bool UpdateRole(Role r)
        {
            try
            {
                var Role = context.Roles.Find(r.Id);

                Role.RoleName = r.RoleName;
                Role.Description = r.Description;
                Role.Status = r.Status;



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
