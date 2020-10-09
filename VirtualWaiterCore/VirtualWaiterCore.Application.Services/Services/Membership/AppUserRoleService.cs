using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Infrastructure;
using VirtualWaiterCore.Resources.Shared;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class AppUserRoleService : ServiceBase, IAppUserRoleService
    {
        #region Dependencies

        public IAppUserRoleRepository AppUserRoleRepository { get; set; }
        public IAppUserRepository AppUserRepository { get; set; }
        public IAppRoleRepository AppRoleRepository { get; set; }
        #endregion

        public List<FunctionalityType> GetPermissions(int userId)
        {
            List<FunctionalityType> result;
            if (AppUserRoleRepository.CheckIfIsAdmin(userId))
            {
                result = EnumHelpers.GetEnumList<FunctionalityType>();
            }
            else
            {
                result = AppUserRoleRepository.GetUserFunctionalities(userId);
            }
            return result;
        }
        public void Delete(int userRoleIdId)
        {
            AppUserRoleRepository.DeleteWhere(x => x.Id == userRoleIdId);
        }

        public object GetUserRoles(int userId)
        {
            return AppUserRoleRepository.GetUserRoles(userId);
        }
        public object GetRoleUsers(int roleId)
        {
            return AppUserRoleRepository.GetRoleUsers(roleId);
        }
        public bool IsUserInRole(int userId, int roleId)
        {
            return AppUserRoleRepository.Any(x => x.AppUserId == userId && x.AppRoleId == roleId);
        }
        public AppUserRoleAddToRoleVM GetAppUserRoleAddToRoleVM(int roleId)
        {
            AppRole role = AppRoleRepository.GetSingle(x => x.Id == roleId);
            if (role == null)
                throw new BussinesException(2, ErrorResource.RoleNotFound);
            AppUserRoleAddToRoleVM result = new AppUserRoleAddToRoleVM()
            {
                RoleId = role.Id,
                RoleName = role.Name,
            };
            return result;
        }

        public AppUserRoleAddToUserVM GetAppUserRoleAddToUserVM(int userId, AppUserRoleAddToUserVM model = null)
        {
            if (model == null)
            {
                model = new AppUserRoleAddToUserVM();
                AppUser user = AppUserRepository.GetSingle(x => x.Id == userId);
                if (user == null)
                    throw new BussinesException(2, ErrorResource.UserNotFound);

                model.UserId = user.Id;
                model.UserName = user.LastName + " " + user.FirstName;
            }
            model.Roles = AppRoleRepository.GetRolesToSelect();

            return model;
        }

        public void AddUserToRole(int userId, int roleId)
        {
            if (IsUserInRole(userId, roleId))
                return;
            AppUserRole crmUserRole = new AppUserRole()
            {
                AppUserId = userId,
                AppRoleId = roleId
            };
            AppUserRoleRepository.Add(crmUserRole);
        }
    }
}
