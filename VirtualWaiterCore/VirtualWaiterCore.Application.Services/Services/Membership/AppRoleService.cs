using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Infrastructure;
using VirtualWaiterCore.Resources.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class AppRoleService : ServiceBase, IAppRoleService
    {
        #region Dependencies
        public IAppRoleRepository AppRoleRepository { get; set; }
        public AppRoleConverter AppRoleConverter { get; set; }
        #endregion

        public AppRoleDetailsVM GetAppRoleDetailsVM(int roleId)
        {
            AppRole role = AppRoleRepository.GetSingle(x => x.Id == roleId);
            AppRoleDetailsVM result = AppRoleConverter.ToAppRoleDetailsVM(role);
            return result;
        }

        public object GetRolesToList()
        {
            return AppRoleRepository.GetRolesToList();
        }

        public int AddRole(AppRoleAddVM model)
        {
            AppRole role = AppRoleConverter.FromAppRoleAddVM(model);
            AppRoleRepository.Add(role);
            AppRoleRepository.Save();
            return role.Id;
        }

        public void EditRole(AppRoleEditVM model)
        {
            AppRole role = AppRoleRepository.GetSingle(x => x.Id == model.Id);
            if (role.AppRoleType == AppRoleType.Administrator)
                throw new BussinesException(1, ErrorResource.EditRoleAdmin);
            role = AppRoleConverter.FromAppRoleEditVM(model, role);
            AppRoleRepository.Edit(role);
        }

        public AppRoleEditVM GetAppRoleEditVM(int id)
        {
            AppRole role = AppRoleRepository.GetSingle(x => x.Id == id);
            if (role.AppRoleType == AppRoleType.Administrator)
                throw new BussinesException(1, ErrorResource.EditRoleAdmin);
            AppRoleEditVM result = AppRoleConverter.ToAppRoleEditVM(role);
            return result;
        }

        public AppRole AddRole(AppRoleType appRoleType, string name, string description = "") {
            AppRole appRole = AppRoleConverter.FromParamsToAppRole(appRoleType, name, description);
            AppRoleRepository.Add(appRole);
            AppRoleRepository.Save();
            return appRole;
        }
    }
}
