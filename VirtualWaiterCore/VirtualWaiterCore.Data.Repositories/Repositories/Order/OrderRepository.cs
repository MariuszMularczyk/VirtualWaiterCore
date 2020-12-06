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

                    if (productsAppetizers.Any())
                    {
                        StringBuilder stringAppetizers = new StringBuilder("");
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
                            ProductTypeName = "Przystawki",
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

                    if (productsMainCourses.Any())
                    {
                        StringBuilder stringMainCourses = new StringBuilder("");
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
                            ProductTypeName = "Dania g³ówne",
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

                    if (productsDeserts.Any())
                    {
                        StringBuilder stringDeserts = new StringBuilder("");
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
                            ProductTypeName = "Desery",
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

        public virtual List<OrderListDTO> GetDrinks()
        {
            List<OrderListDTO> orders = new List<OrderListDTO>();

            List<OrderItemDTO> ordersId = Context.Orders.Select(x => new OrderItemDTO()
            {
                OrderId = x.Id,
                Table = x.Table,
                OrderStatus = x.OrderStatus,
                TimeOfOrder = x.TimeOfOrder,
                DrinksStatus = x.DrinksStatus,
            }).Where(x => x.OrderStatus != Dictionaries.OrderStatusEnum.Done).ToList();
            int OrderItemId = 1;
            foreach (OrderItemDTO item in ordersId)
            {
                if (item.DrinksStatus == Dictionaries.OrderStatusEnum.Awaiting)
                {
                    List<ProductItemDTO> drinks = Context.ProductsOrders.Select(x => new ProductItemDTO()
                    {
                        Quantity = x.Quantity,
                        ProductName = x.Product.Name,
                        ProductType = x.Product.ProductType,
                        OrderId = x.OrderId,
                        TimeOfPreparation = x.Product.TimeOfPreparation
                    }).Where(x => x.ProductType == Dictionaries.ProductType.Drink && x.OrderId == item.OrderId).ToList();

                    if (drinks.Any())
                    {
                        StringBuilder stringDrinks = new StringBuilder("");
                        foreach (ProductItemDTO product in drinks)
                        {
                            stringDrinks.Append(product.Quantity);
                            stringDrinks.Append(" x ");
                            stringDrinks.Append(product.ProductName);
                            stringDrinks.Append(", \n");
                        }
                        OrderListDTO appetizers = new OrderListDTO()
                        {
                            OrderItemId = OrderItemId++,
                            OrderId = item.OrderId,
                            Table = item.Table,
                            Order = stringDrinks.ToString(),
                            TimeOfOrder = item.TimeOfOrder,
                            TimeOfPreparation = drinks.Max(x => x.TimeOfPreparation),
                            ProductType = Dictionaries.ProductType.Appetizer,
                        };
                        orders.Add(appetizers);
                    }
                }
            }
            return orders;
        }
    }
}
