using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Infrastructure;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class AppUserRepository : Repository<AppUser, MainDatabaseContext>, IAppUserRepository
    {

        public AppUserRepository(MainDatabaseContext context)
         : base(context)
        {

        }

        public object GetUsersLookup()
        {
            List<SelectModelBinder<int>> result = _dbset.Select(x => new SelectModelBinder<int>() { Value = x.Id, Text = x.LastName + " " + x.FirstName }).ToList();
            
            return result;
        }
        public object GetUsersToList()
        {
            var result = _dbset.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.IsActive,
                x.Email,
                x.Login,
                Role = x.AppUserRoles.Select(r => r.AppRole.AppRoleType)
            });
            
            return result;
        }
        public string GetActiveUserIdByEmail(string email)
        {
            email = email.Trim().ToLower();
            return null;
            //return _dbset.Where(x => x.IsActive && x.Email == email).Select(x => x.WebUserId).FirstOrDefault();
        }

        public int GetUnknownUserId()
        {
            return Context.SystemUsers.FirstOrDefault(x => x.Email == SystemUsers.UnknownUserEmail).Id;
        }
    }
}
