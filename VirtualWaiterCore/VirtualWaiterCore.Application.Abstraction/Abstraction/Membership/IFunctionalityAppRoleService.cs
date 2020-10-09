using VirtualWaiterCore.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Application.Abstraction;


namespace VirtualWaiterCore.Application
{
    public interface IFunctionalityAppRoleService : IService
    {
        void Delete(int functionalityRoleId);
        object GetRoleFunctionalities(int roleId);
        FunctionalityAppRoleAddVM GetFunctionalityAppRoleAddVM(int roleId);
        void Add(int functionalityId, int roleId);
        object GetFunctionalitiesToAdd(int roleId);
    }
}
