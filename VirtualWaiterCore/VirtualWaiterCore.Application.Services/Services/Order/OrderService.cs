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


        public List<OrderListDTO> Add(OrderAddVM model)
        {
            Order order = new Order()
            {
                Table = model.Table,
                OrderStatus = OrderStatusEnum.Awaiting,
                AppetizerStatus = OrderStatusEnum.Awaiting,
                MainCourseStatus = OrderStatusEnum.Awaiting,
                DessertsStatus = OrderStatusEnum.Awaiting,
                DrinksStatus = OrderStatusEnum.Awaiting,
                TimeOfOrder = DateTime.Now
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
            return _orderRepository.GetOrders();
        }

        public virtual List<OrderListDTO> GetOrders()
        {
            List<OrderListDTO> orders = _orderRepository.GetOrders();
            List<int> orderIds = _orderRepository.GetOrdersIds();

            List<OrderListDTO> newOrders = new List<OrderListDTO>();


            foreach (int orderId in orderIds) {

                OrderListDTO appetizers1 = orders.FirstOrDefault(x => x.OrderId == orderId && x.ProductType == ProductType.Drink);

                OrderListDTO appetizers = orders.FirstOrDefault(x => x.OrderId == orderId && x.ProductType == ProductType.Appetizer);
                OrderListDTO mainCourses = orders.FirstOrDefault(x => x.OrderId == orderId && x.ProductType == ProductType.MainCourse);
                OrderListDTO desserts = orders.FirstOrDefault(x => x.OrderId == orderId && x.ProductType == ProductType.Dessert);
                if(appetizers != null)
                {
                    appetizers.TimeOfSugestedPrepare = appetizers.TimeOfOrder.AddMinutes(15-(double)appetizers.TimeOfPreparation);
                    newOrders.Add(appetizers);
                }

                if (mainCourses != null && appetizers != null)
                {
                    DateTime appetizerTimeOfDone = (DateTime)appetizers.TimeOfSugestedPrepare;
                    mainCourses.TimeOfSugestedPrepare = appetizerTimeOfDone.AddMinutes(15 - (double)mainCourses.TimeOfPreparation);
                    newOrders.Add(mainCourses);
                }
                else if (mainCourses != null && appetizers == null)
                {
                    mainCourses.TimeOfSugestedPrepare = mainCourses.TimeOfOrder.AddMinutes(15 - (double)mainCourses.TimeOfPreparation);
                    newOrders.Add(mainCourses);
                }

                if (mainCourses != null && appetizers != null && desserts != null)
                {
                    DateTime mainCoursesTimeOfDone = (DateTime)mainCourses.TimeOfSugestedPrepare;
                    desserts.TimeOfSugestedPrepare = mainCoursesTimeOfDone.AddMinutes(15 - (double)desserts.TimeOfPreparation);
                    newOrders.Add(desserts);
                }
                else if (mainCourses != null && appetizers == null && desserts != null)
                {
                    DateTime mainCoursesTimeOfDone = (DateTime)mainCourses.TimeOfSugestedPrepare;
                    desserts.TimeOfSugestedPrepare = mainCoursesTimeOfDone.AddMinutes(15 - (double)desserts.TimeOfPreparation);
                    newOrders.Add(desserts);
                }
                else if (mainCourses == null && appetizers != null && desserts != null)
                {
                    DateTime appetizerTimeOfDone = (DateTime)appetizers.TimeOfSugestedPrepare;
                    desserts.TimeOfSugestedPrepare = appetizerTimeOfDone.AddMinutes(15 - (double)desserts.TimeOfPreparation);
                    newOrders.Add(desserts);
                }
                else if (mainCourses == null && appetizers == null && desserts != null)
                {
                    desserts.TimeOfSugestedPrepare = desserts.TimeOfOrder.AddMinutes(15 - (double)desserts.TimeOfPreparation);
                    newOrders.Add(desserts);
                }
            }

            return newOrders.OrderBy(x => x.TimeOfSugestedPrepare).ToList();
        }
        public virtual List<OrderListDTO> GetDrinks()
        {
            return _orderRepository.GetDrinks();
        }
        public virtual void SetStatus(int orderId, int productType)
        {
            Order order = _orderRepository.GetSingle(x => x.Id == orderId);

            switch (productType)
            {
                case 1:
                    order.AppetizerStatus = OrderStatusEnum.Done;
                    break;
                case 2:
                    order.DessertsStatus = OrderStatusEnum.Done;
                    break;
                case 3:
                    order.DrinksStatus = OrderStatusEnum.Done;
                    break;
                case 4:
                    order.MainCourseStatus = OrderStatusEnum.Done;
                    break;
            }
            if(order.AppetizerStatus == OrderStatusEnum.Done && order.DessertsStatus == OrderStatusEnum.Done && order.DrinksStatus == OrderStatusEnum.Done && order.MainCourseStatus == OrderStatusEnum.Done)
            {
                order.OrderStatus = OrderStatusEnum.Done;
            }
            else
            {
                order.OrderStatus = OrderStatusEnum.InProgress;
            }

            _orderRepository.Edit(order);
            _orderRepository.Save();
        }
    }
}
