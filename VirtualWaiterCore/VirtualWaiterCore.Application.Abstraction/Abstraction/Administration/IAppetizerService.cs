using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VirtualWaiterCore.Data;

namespace VirtualWaiterCore.Application
{
    public interface IAppetizerService : IService
    {
        void Add(AppetizerAddVM model);
        List<AppetizerListDTO> GetAppetizers();
        AppetizerEditVM GetAppetizer(int id);
        void Edit(AppetizerEditVM model);
        void Delete(int id);
    }
}