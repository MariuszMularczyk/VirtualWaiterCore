using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface IApplicationFileRepository : IRepository<ApplicationFile>
    {
        ApplicationFile GetImage(int id);
    }
}
