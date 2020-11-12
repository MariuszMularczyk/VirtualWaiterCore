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
        public IOrderRepository _orderRepository { get; set; }
        public IProductRepository _productRepository { get; set; }
        public IProductOrderRepository _productOrderRepository { get; set; }
        #endregion


        public void Add(OrderAddVM model)
        {
            Order order = new Order()
            {
                Table = model.Table,
                OrderStatus = OrderStatusEnum.Awaiting
            };

            _orderRepository.Add(order);
            _orderRepository.Save();
            foreach(var item in model.ProductOrders)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    Order = order,
                    Product = _productRepository.GetSingle(x => x.Id == item.ProductId),
                    Quantity = item.Quantity
                };
                _productOrderRepository.Add(productOrder);
            }
            _productOrderRepository.Save();
        }

    }
}
