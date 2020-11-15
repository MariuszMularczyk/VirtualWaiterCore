using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Domain;
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
    public interface IOrderService : IService
    {
        void Add(OrderAddVM model);
        List<OrderListDTO> GetOrders();
    }
}