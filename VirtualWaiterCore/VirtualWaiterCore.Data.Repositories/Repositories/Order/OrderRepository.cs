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

/*        public virtual List<OrderListDTO> GetOrders()
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
                        productsAppetizers.OrderByDescending(x => x.TimeOfPreparation);
                        StringBuilder stringAppetizers = new StringBuilder("");
                        List<decimal> appetizersTimes = new List<decimal>();
                        foreach (ProductItemDTO product in productsAppetizers)
                        {
                            stringAppetizers.Append(product.Quantity);
                            stringAppetizers.Append(" x ");
                            stringAppetizers.Append(product.ProductName);
                            stringAppetizers.Append(", \n");
                            appetizersTimes.Add(product.TimeOfPreparation);
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
                            TimeOfPreparations = appetizersTimes,
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
                        productsMainCourses.OrderByDescending(x => x.TimeOfPreparation);
                        StringBuilder stringMainCourses = new StringBuilder("");
                        List<decimal> maincoursesTimes = new List<decimal>();
                        foreach (ProductItemDTO product in productsMainCourses)
                        {
                            stringMainCourses.Append(product.Quantity);
                            stringMainCourses.Append(" x ");
                            stringMainCourses.Append(product.ProductName);
                            stringMainCourses.Append(", \n");
                            maincoursesTimes.Add(product.TimeOfPreparation);
                        }
                        OrderListDTO mainCourses = new OrderListDTO()
                        {
                            OrderItemId = OrderItemId++,
                            OrderId = item.OrderId,
                            ProductTypeName = "Dania g��wne",
                            Table = item.Table,
                            Order = stringMainCourses.ToString(),
                            TimeOfOrder = item.TimeOfOrder,
                            TimeOfPreparation = productsMainCourses.Max(x => x.TimeOfPreparation),
                            TimeOfPreparations = maincoursesTimes,
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
                        productsDeserts.OrderByDescending(x => x.TimeOfPreparation);
                        StringBuilder stringDeserts = new StringBuilder("");
                        List<decimal> desertssTimes = new List<decimal>();
                        foreach (ProductItemDTO product in productsDeserts)
                        {
                            stringDeserts.Append(product.Quantity);
                            stringDeserts.Append(" x ");
                            stringDeserts.Append(product.ProductName);
                            stringDeserts.Append(", \n");
                            desertssTimes.Add(product.TimeOfPreparation);
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
                            TimeOfPreparations = desertssTimes,
                            ProductType = Dictionaries.ProductType.Dessert,
                        };
                        orders.Add(deserts);
                    }
                }
            }
            return orders;
        }*/

        public virtual List<ProductItemDataDTO> GetOrders()
        {
            List<ProductItemDataDTO> orders = new List<ProductItemDataDTO>();

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
            foreach (OrderItemDTO item in ordersId)
            {
                int appetizerPriority = 0;
                int mainCopursesPriority = 0;
                int dessertPriority = 0;
                List<ProductItemDataDTO> products = Context.ProductsOrders.Where(x => x.OrderId == item.OrderId && x.Status != Dictionaries.OrderStatusEnum.Done && x.Product.ProductType != Dictionaries.ProductType.Drink).Select(x => new ProductItemDataDTO()
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductType = x.Product.ProductType,
                    OrderId = x.OrderId,
                    Table = x.Order.Table,
                    TimeOfPreparation = x.Product.TimeOfPreparation
                }).ToList();

                if(products.Any(x => x.ProductType == Dictionaries.ProductType.Appetizer) && products.Any(x => x.ProductType == Dictionaries.ProductType.MainCourse))
                {
                    appetizerPriority = 1;
                    mainCopursesPriority = 2;
                    dessertPriority = 10;
                }
                else if (products.Any(x => x.ProductType == Dictionaries.ProductType.Appetizer) )
                {
                    appetizerPriority = 1;
                    dessertPriority = 2;
                    mainCopursesPriority = 999;
                    
                }
                else if (products.Any(x => x.ProductType == Dictionaries.ProductType.MainCourse))
                {
                    appetizerPriority = 999;
                    dessertPriority = 10;
                    mainCopursesPriority = 1;

                }
                else 
                {
                    appetizerPriority = 999;
                    dessertPriority = 1;
                    mainCopursesPriority = 999;

                }

                foreach(ProductItemDataDTO product in products)
                {
                    switch (product.ProductType)
                    {
                        case Dictionaries.ProductType.Appetizer:
                            product.Priority = appetizerPriority;
                            product.ProductTypeName = "Przystawka";
                            break;
                        case Dictionaries.ProductType.MainCourse:
                            product.Priority = mainCopursesPriority;
                            product.ProductTypeName = "Danie g��wne";
                            break;
                        case Dictionaries.ProductType.Dessert:
                            product.Priority = dessertPriority;
                            product.ProductTypeName = "Deser";
                            break;
                    }
                }
                orders.AddRange(products);
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
                    List<ProductItemDTO> drinksb = Context.ProductsOrders.Select(x => new ProductItemDTO()
                    {
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductType = x.Product.ProductType,
                        OrderId = x.OrderId,
                        TimeOfPreparation = x.Product.TimeOfPreparation
                    }).Where(x => x.ProductType == Dictionaries.ProductType.Drink && x.OrderId == item.OrderId).ToList();

                    List<ProductItemDTO> drinks =
                    drinksb.GroupBy(x => x)
                    .Select(x => new ProductItemDTO()
                    {
                        Quantity = x.Count(),
                        ProductName = x.Key.ProductName,
                        OrderId = x.First().OrderId
                    })
                    .OrderByDescending(x => x.Quantity).ToList();



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
                            ProductType = Dictionaries.ProductType.Drink,
                        };
                        orders.Add(appetizers);
                    }
                }
            }
            return orders.OrderBy(x => x.TimeOfOrder).ToList();
        }

        public virtual List<int> GetOrdersIds()
        {
            List<int>  ids = Context.Orders.Where(x => x.OrderStatus != Dictionaries.OrderStatusEnum.Done).Select(x => x.Id).ToList();
            return ids;
        }

    }
}
