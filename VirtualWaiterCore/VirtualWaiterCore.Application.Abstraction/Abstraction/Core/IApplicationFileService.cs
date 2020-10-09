using VirtualWaiterCore.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public interface IApplicationFileService : IService
    {
        ImageVM GetImage(int id);
    }
}
