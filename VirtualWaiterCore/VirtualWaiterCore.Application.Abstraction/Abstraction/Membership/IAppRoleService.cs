using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Application.Abstraction;

namespace VirtualWaiterCore.Application
{
    public interface IAppRoleService : IService
    {
        object GetRolesToList();
        AppRoleDetailsVM GetAppRoleDetailsVM(int roleId);
        int AddRole(AppRoleAddVM model);
        void EditRole(AppRoleEditVM model);
        AppRoleEditVM GetAppRoleEditVM(int id);
        AppRole AddRole(AppRoleType appRoleType, string name, string description = "");
    }
}
