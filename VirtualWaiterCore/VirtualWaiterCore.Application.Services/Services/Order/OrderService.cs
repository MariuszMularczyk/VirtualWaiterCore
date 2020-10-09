using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class OrderService : ServiceBase, IOrderService
    {
        #region Dependencies
        public IOrderRepository OrderRepository { get; set; }
        #endregion

        public void Add(OrderAddVM model)
        {
            Order order = new Order()
            {
                Description = model.Order,
                OrderStatus = (OrderStatusEnum)model.OrderStatusId
        };
            OrderRepository.Add(order);
            OrderRepository.Save();
        }

    }
}
