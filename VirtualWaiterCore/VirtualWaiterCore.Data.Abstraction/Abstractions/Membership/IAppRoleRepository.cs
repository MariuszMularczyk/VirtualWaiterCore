using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface IAppRoleRepository : IRepository<AppRole>
    {
        object GetRolesToList();
        List<SelectModelBinder<int>> GetRolesToSelect();
    }
}
