using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface IFunctionalityAppRoleRepository : IRepository<FunctionalityAppRole>
    {
        object GetRoleFunctionality(int roleId);
        object GetFunctionalitiesToAdd( int roleId);
    }
}
