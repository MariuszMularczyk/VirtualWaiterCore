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
    public interface IDessertService : IService
    {
        void Add(DessertAddVM model);
        List<DessertListDTO> GetDesserts();
        DessertEditVM GetDessert(int id);
        void Edit(DessertEditVM model);
    }
}