using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class OrderRepository : Repository<Order, MainDatabaseContext>, IOrderRepository
    {
        public OrderRepository(MainDatabaseContext context) : base(context)
        { }

        public virtual List<OrderListDTO> GetOrders()
        {
            List<OrderListDTO> orders = new List<OrderListDTO>();

            List<OrderItemDTO> ordersId = Context.Orders.Select(x => new OrderItemDTO()
            {
                OrderId = x.Id,
                Table = x.Table,
                OrderStatus = x.OrderStatus,
                TimeOfOrder = x.TimeOfOrder,
                AppetizerStatus = x.AppetizerStatus,
                MainCourseStatus = x.MainCourseStatus,
                DessertsStatus = x.DessertsStatus
            }).Where(x => x.OrderStatus != Dictionaries.OrderStatusEnum.Done).ToList();
            int OrderItemId = 1;
            foreach(OrderItemDTO item in ordersId)
            {
                if (item.AppetizerStatus == Dictionaries.OrderStatusEnum.Awaiting)
                {
                    List<ProductItemDTO> productsAppetizers = Context.ProductsOrders.Select(x => new ProductItemDTO()
                    {
                        Quantity = x.Quantity,
                        ProductName = x.Product.Name,
                        ProductType = x.Product.ProductType,
                        OrderId = x.OrderId,
                        TimeOfPreparation = x.Product.TimeOfPreparation
                    }).Where(x => x.ProductType == Dictionaries.ProductType.Appetizer && x.OrderId == item.OrderId).ToList();

                    if (productsAppetizers.Count() > 0)
                    {
                        StringBuilder stringAppetizers = new StringBuilder("Przystawki: \n");
                        foreach (ProductItemDTO product in productsAppetizers)
                        {
                            stringAppetizers.Append(product.Quantity);
                            stringAppetizers.Append(" x ");
                            stringAppetizers.Append(product.ProductName);
                            stringAppetizers.Append(", \n");
                        }
                        OrderListDTO appetizers = new OrderListDTO()
                        {
                            OrderItemId = OrderItemId++,
                            OrderId = item.OrderId,
                            Table = item.Table,
                            Order = stringAppetizers.ToString(),
                            TimeOfOrder = item.TimeOfOrder,
                            TimeOfPreparation = productsAppetizers.Max(x => x.TimeOfPreparation),
                            ProductType = Dictionaries.ProductType.Appetizer,
                        };
                        orders.Add(appetizers);
                    }
                }
                if (item.MainCourseStatus == Dictionaries.OrderStatusEnum.Awaiting)
                {
                    List<ProductItemDTO> productsMainCourses = Context.ProductsOrders.Select(x => new ProductItemDTO()
                    {
                        Quantity = x.Quantity,
                        ProductName = x.Product.Name,
                        ProductType = x.Product.ProductType,
                        OrderId = x.OrderId,
                        TimeOfPreparation = x.Product.TimeOfPreparation
                    }).Where(x => x.ProductType == Dictionaries.ProductType.MainCourse && x.OrderId == item.OrderId).ToList();

                    if (productsMainCourses.Count() > 0)
                    {
                        StringBuilder stringMainCourses = new StringBuilder("Dania g³ówne: \n");
                        foreach (ProductItemDTO product in productsMainCourses)
                        {
                            stringMainCourses.Append(product.Quantity);
                            stringMainCourses.Append(" x ");
                            stringMainCourses.Append(product.ProductName);
                            stringMainCourses.Append(", \n");
                        }
                        OrderListDTO mainCourses = new OrderListDTO()
                        {
                            OrderItemId = OrderItemId++,
                            OrderId = item.OrderId,
                            Table = item.Table,
                            Order = stringMainCourses.ToString(),
                            TimeOfOrder = item.TimeOfOrder,
                            TimeOfPreparation = productsMainCourses.Max(x => x.TimeOfPreparation),
                            ProductType = Dictionaries.ProductType.MainCourse,
                        };
                        orders.Add(mainCourses);
                    }
                }
                if (item.DessertsStatus == Dictionaries.OrderStatusEnum.Awaiting)
                {
                    List<ProductItemDTO> productsDeserts = Context.ProductsOrders.Select(x => new ProductItemDTO()
                    {
                        Quantity = x.Quantity,
                        ProductName = x.Product.Name,
                        ProductType = x.Product.ProductType,
                        OrderId = x.OrderId,
                        TimeOfPreparation = x.Product.TimeOfPreparation
                    }).Where(x => x.ProductType == Dictionaries.ProductType.Dessert && x.OrderId == item.OrderId).ToList();

                    if (productsDeserts.Count() > 0)
                    {
                        StringBuilder stringDeserts = new StringBuilder("Desery: \n");
                        foreach (ProductItemDTO product in productsDeserts)
                        {
                            stringDeserts.Append(product.Quantity);
                            stringDeserts.Append(" x ");
                            stringDeserts.Append(product.ProductName);
                            stringDeserts.Append(", \n");
                        }
                        OrderListDTO deserts = new OrderListDTO()
                        {
                            OrderItemId = OrderItemId++,
                            OrderId = item.OrderId,
                            Table = item.Table,
                            Order = stringDeserts.ToString(),
                            TimeOfOrder = item.TimeOfOrder,
                            TimeOfPreparation = productsDeserts.Max(x => x.TimeOfPreparation),
                            ProductType = Dictionaries.ProductType.Dessert,
                        };
                        orders.Add(deserts);
                    }
                }
            }
            return orders;
        }
    }
}
