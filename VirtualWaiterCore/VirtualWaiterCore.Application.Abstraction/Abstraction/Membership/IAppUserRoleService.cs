using VirtualWaiterCore.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Application.Abstraction;


namespace VirtualWaiterCore.Application
{
    public interface IAppUserRoleService : IService
    {
        List<FunctionalityType> GetPermissions(int userId);
        object GetUserRoles(int userId);
        void Delete(int userRoleId);
        object GetRoleUsers(int roleId);
        AppUserRoleAddToRoleVM GetAppUserRoleAddToRoleVM(int roleId);
        bool IsUserInRole(int userId, int roleId);
        void AddUserToRole(int userId, int roleId);
        AppUserRoleAddToUserVM GetAppUserRoleAddToUserVM(int userId, AppUserRoleAddToUserVM model = null);
    }
}
