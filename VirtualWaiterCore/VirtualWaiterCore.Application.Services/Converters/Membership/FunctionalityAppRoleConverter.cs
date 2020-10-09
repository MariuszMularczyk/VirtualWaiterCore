using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class FunctionalityAppRoleConverter : ConverterBase
    {
        public FunctionalityAppRoleAddVM ToFunctionalityAppRoleAddVM(AppRole role)
        {
            FunctionalityAppRoleAddVM result = new FunctionalityAppRoleAddVM()
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return result;
        }
    }
}
