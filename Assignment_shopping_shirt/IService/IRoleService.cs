using Assignment_shopping_shirt.Models;

namespace Assignment_shopping_shirt.IService
{
    public interface IRoleService
    {
        public bool CreatRole(Role r);
        public bool UpdateRole(Role r);
        public bool DeleteRole(Guid id);

        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid id);
        public List<Role> GetRolesByName(string name);
    }
}
