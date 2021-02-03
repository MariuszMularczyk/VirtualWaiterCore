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
        public IAppSettingsRepository _appSettingsRepository { get; set; }
        #endregion
        public OrderService(IProductRepository productRepository, IAppSettingsRepository appSettingsRepository, IProductOrderRepository productOrderRepository, IOrderRepository orderRepository )
        {
            _productRepository = productRepository;
            _appSettingsRepository = appSettingsRepository;
            _productOrderRepository = productOrderRepository;
            _orderRepository = orderRepository;
            
        }

        public List<List<ProductItemDataDTO>> Add(OrderAddVM model)
        {

            bool appetizerStatus = false;
            bool mainCourseStatus = false;
            bool dessertsStatus = false;
            bool drinksStatus = false;

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
                for (int i = 0; i < item.Quantity; i++)
                {
                    ProductOrder productOrder = new ProductOrder()
                    {
                        Order = order,
                        Product = _productRepository.GetSingle(x => x.Id == item.ProductId),
                        Status = OrderStatusEnum.Awaiting,
                    };
                    switch (productOrder.Product.ProductType)
                    {
                        case ProductType.Appetizer:
                            appetizerStatus = true;
                            break;
                        case ProductType.MainCourse:
                            mainCourseStatus = true;
                            break;
                        case ProductType.Dessert:
                            dessertsStatus = true;
                            break;
                        case ProductType.Drink:
                            drinksStatus = true;
                            break;
                    }
               
                    _productOrderRepository.Add(productOrder);
                }
                
            }

            _productOrderRepository.Save();
            if (!appetizerStatus)
                order.AppetizerStatus = OrderStatusEnum.Done;
            if (!mainCourseStatus)
                order.MainCourseStatus = OrderStatusEnum.Done;
            if (!dessertsStatus)
                order.DessertsStatus = OrderStatusEnum.Done;
            if (!drinksStatus)
                order.DrinksStatus = OrderStatusEnum.Done;
            _orderRepository.Edit(order);
            _orderRepository.Save();
            return GetOrders();
        }

        public virtual List<List<ProductItemDataDTO>> GetOrders()
        {
            int numberOfCooks;
            AppSetting numberOfCooksAppSetting = _appSettingsRepository.GetSingle(x => x.Type == AppSettingEnum.NumberOfCooks);
            if(numberOfCooksAppSetting is null)
            {
                _appSettingsRepository.Add(new AppSetting()
                {
                    Type = AppSettingEnum.NumberOfCooks,
                    Value = "2",
                });
                numberOfCooks = 2;
            }
            else
            {
                numberOfCooks = Int32.Parse(numberOfCooksAppSetting.Value);
            }
            List<ProductItemDataDTO> orders = _orderRepository.GetOrders();
            foreach(ProductItemDataDTO product in orders)
            {
                product.Measure = product.Priority * product.TimeOfPreparation;
            }
            List<ProductItemDataDTO> products = orders.OrderBy(x => x.Measure).ToList();
            List<List<ProductItemDataDTO>> productPerCook = new List<List<ProductItemDataDTO>>();
            for (int i= 0; i < numberOfCooks; i++ )
            {
                productPerCook.Add(new List<ProductItemDataDTO>());
            }
            foreach(ProductItemDataDTO productItem in products)
            {
                productPerCook = productPerCook.OrderBy(x => x.Sum(x => x.TimeOfPreparation)).ToList();
                productPerCook[0].Add(productItem);
            }

            return productPerCook;
        }
        public virtual List<OrderListDTO> GetDrinks()
        {
            return _orderRepository.GetDrinks();
        }
        public virtual List<List<ProductItemDataDTO>> SetStatus(int orderId)
        {
            ProductOrder productOrder = _productOrderRepository.GetSingle(x => x.Id == orderId);
            productOrder.Status = OrderStatusEnum.Done;
            _productOrderRepository.Edit(productOrder);
            _productOrderRepository.Save();
            List<ProductOrder> productOrders = _productOrderRepository.GetAll(x => x.OrderId == productOrder.OrderId && x.Status == OrderStatusEnum.Awaiting).ToList();
            if (!productOrders.Any())
            {
                Order order =  _orderRepository.GetSingle(x => x.Id == productOrder.OrderId);
                switch ((int)productOrder.Product.ProductType)
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
                if (order.AppetizerStatus == OrderStatusEnum.Done && order.DessertsStatus == OrderStatusEnum.Done && order.DrinksStatus == OrderStatusEnum.Done && order.MainCourseStatus == OrderStatusEnum.Done)
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
            return GetOrders();

        }

        public virtual void SetStatus(int orderId, int productType)
        {
            Order order = _orderRepository.GetSingle(x => x.Id == orderId);

            order.DrinksStatus = OrderStatusEnum.Done;
            List<ProductOrder>  productOrders = _productOrderRepository.GetAll(x => x.OrderId == orderId && x.Product.ProductType == ProductType.Drink).ToList();
            foreach(ProductOrder productOrder  in productOrders)
            {
                productOrder.Status = OrderStatusEnum.Done;
            }
            _productOrderRepository.EditRange(productOrders);
            _productOrderRepository.Save();
            if (order.AppetizerStatus == OrderStatusEnum.Done && order.DessertsStatus == OrderStatusEnum.Done && order.DrinksStatus == OrderStatusEnum.Done && order.MainCourseStatus == OrderStatusEnum.Done)
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
        public virtual void SetCoocks(int numberOfCoocks)
        {
            if (numberOfCoocks < 1)
            {
                throw new InvalidOperationException("Number must be higher than 0 ");
            }
            AppSetting numberOfCooksAppSetting = _appSettingsRepository.GetSingle(x => x.Type == AppSettingEnum.NumberOfCooks);
            if (numberOfCooksAppSetting is null)
            {
                _appSettingsRepository.Add(new AppSetting()
                {
                    Type = AppSettingEnum.NumberOfCooks,
                    Value = numberOfCoocks.ToString(),
                });
            }
            else
            {
                numberOfCooksAppSetting.Value = numberOfCoocks.ToString();
                _appSettingsRepository.Edit(numberOfCooksAppSetting);
            }
            _appSettingsRepository.Save();
        }

    }
}
