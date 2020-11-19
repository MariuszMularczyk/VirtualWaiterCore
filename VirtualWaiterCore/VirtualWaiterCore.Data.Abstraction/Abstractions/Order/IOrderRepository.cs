using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderListDTO> GetOrders();
        List<OrderListDTO> GetDrinks();
    }
}
