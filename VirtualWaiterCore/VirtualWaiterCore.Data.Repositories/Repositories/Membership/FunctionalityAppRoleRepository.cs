using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class FunctionalityAppRoleRepository : Repository<FunctionalityAppRole, MainDatabaseContext>, IFunctionalityAppRoleRepository
    {
        public FunctionalityAppRoleRepository(MainDatabaseContext context)
         : base(context)
        {
        }

        public object GetRoleFunctionality( int roleId)
        {
            List<RoleFunctionalityListDTO> result = _dbset.Where(x => x.AppRoleId == roleId).Select(x => new RoleFunctionalityListDTO()
            {
                FunctionalityRoleId = x.Id,
                Description = x.Functionality.Description,
                Name = x.Functionality.Name
            }).ToList();
           
            return result;
        }
        public object GetFunctionalitiesToAdd(int roleId)
        {
            IQueryable<RoleFunctionalityToAddListDTO> result = from functionality in Context.Functionalities
                                                              join functionalityRole in Context.FunctionalityAppRoles.Where(x => x.AppRoleId == roleId) on functionality.Id equals functionalityRole.FunctionalityId into joinedFunctionalityRoles
                                                              from data in joinedFunctionalityRoles.DefaultIfEmpty()
                                                              select new RoleFunctionalityToAddListDTO()
                                                              {
                                                                  Id = functionality.Id,
                                                                  Description = functionality.Description,
                                                                  Name = functionality.Name,
                                                                  IsAdded = data != null
                                                              };

            
            return result;
        }
    }
}
