using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Data
{
    public class AppUserRoleRepository : Repository<AppUserRole, MainDatabaseContext>, IAppUserRoleRepository
    {
        public AppUserRoleRepository(MainDatabaseContext context)
         : base(context)
        {
        }

        public List<FunctionalityType> GetUserFunctionalities(int userId)
        {
            return _dbset.Where(x => x.Id == userId).SelectMany(x => x.AppRole.FunctionalityAppRoles).Select(x => x.Functionality.FunctionalityType).Distinct().ToList();
        }

        public bool CheckIfIsAdmin(int userId)
        {
            return _dbset.Where(x => x.Id == userId).Any(x => x.AppRole.AppRoleType == AppRoleType.Administrator);
        }

        public object GetUserRoles(int userId)
        {
            List<UserRoleListDTO> result = _dbset.Where(x => x.AppUserId == userId).Select(x => new UserRoleListDTO()
            {
                UserRoleId = x.Id,
                RoleName = x.AppRole.Name
            }).ToList();
            
            return result;
        }
        public object GetRoleUsers( int roleId)
        {
            List<RoleUserListDTO> result = _dbset.Where(x => x.AppRoleId == roleId).Select(x => new RoleUserListDTO()
            {
                UserRoleId = x.Id,
                FirstName = x.AppUser.FirstName,
                LastName = x.AppUser.LastName,
                FullName = x.AppUser.LastName + " " + x.AppUser.FirstName
            }).ToList();
            return result;
        }
    }
}
