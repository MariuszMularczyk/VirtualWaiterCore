using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.WebAPI;
using VirtualWaiterCore.WebAPI.Controllers;

namespace VirtualWaiterTests
{
    public class OrderTests
    {

        private static DbContextOptions<MainDatabaseContext> _options;
        private OrderRepository OrderRepository { get; set; }
        private ProductRepository ProductRepository { get; set; }
        private ProductOrderRepository ProductOrderRepository { get; set; }
        private AppSettingsRepository AppSettingsRepository { get; set; }
        private OrderService OrderService { get; set; }
        private OrderController OrderController { get; set; }

        private MainDatabaseContext Context { get; set; }

        public OrderTests()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var builder = new DbContextOptionsBuilder<MainDatabaseContext>();
            var connectionString = configuration.GetConnectionString("MainDatabaseContext");

            builder.UseSqlServer(connectionString);
            builder.UseLazyLoadingProxies();
            _options = builder.Options;
            Context = new MainDatabaseContext(_options);
            OrderRepository = new OrderRepository(Context);
            ProductRepository = new ProductRepository(Context);
            ProductOrderRepository = new ProductOrderRepository(Context);
            AppSettingsRepository = new AppSettingsRepository(Context);
            OrderService = new OrderService(ProductRepository, AppSettingsRepository, ProductOrderRepository, OrderRepository);
            OrderController = new OrderController(OrderService);
        }
        [Test, Isolated]
        public void Get_Drink_Orders_ShouldBeOrdered()
        {

            var context = new MainDatabaseContext(_options);

            var productRepository = new OrderRepository(context);
            var list = productRepository.GetDrinks();
            if(list.Count > 0)
            {
                DateTime time;
                time = list[0].TimeOfOrder;
                foreach (var element in list)
                {
                        Assert.That(element.TimeOfOrder, Is.GreaterThanOrEqualTo(time));
                        time = element.TimeOfOrder;
                }

            }
            else
            {
                Assert.True(true);
            }

        }

        [Test, Isolated]
        public void Add_Order_By_Controller_ShouldAddProductToDatabased()
        {

            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var model = new Product
            {
                Name = "name",
                Description = "Test",
                Image = arr1,
                ImageTumb = arr1,
                Price = 999,
                ProductType = ProductType.Appetizer,
                TimeOfPreparation = 999
            };
            ProductRepository.Add(model);
            ProductRepository.Save();
            Product product = ProductRepository.GetSingle(x => x.Name == "name" && x.Description == "Test");

            List<ProductOrderAddVM> productOrders = new List<ProductOrderAddVM>();
            productOrders.Add(new ProductOrderAddVM() { ProductId = product.Id, Quantity = 1 });
            OrderAddVM orderModel = new OrderAddVM()
            {
                Table = "stolik Test",
                ProductOrders = productOrders
            };
            OrderController.Add(orderModel);

            Order order = OrderRepository.GetSingle(x => x.Table == "stolik Test");
            ProductOrder productOrder = ProductOrderRepository.GetSingle(x => x.ProductId == product.Id && x.OrderId == order.Id);

            Assert.IsNotNull(productOrder);

        }

        [Test, Isolated]
        public void Set_Cooks_Number()
        {
            OrderService.SetCoocks(2);
            AppSetting appSetting = AppSettingsRepository.GetSingle(x => x.Type == AppSettingEnum.NumberOfCooks);
            Assert.That(appSetting.Value, Is.EqualTo("2"));

        }
        [Test, Isolated]
        public void Set_Order_Status_By_Controller_ShouldAddProductToDatabased()
        {

            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var model = new Product
            {
                Name = "name",
                Description = "Test",
                Image = arr1,
                ImageTumb = arr1,
                Price = 999,
                ProductType = ProductType.Appetizer,
                TimeOfPreparation = 999
            };
            ProductRepository.Add(model);
            ProductRepository.Save();
            Product product = ProductRepository.GetSingle(x => x.Name == "name" && x.Description == "Test");

            List<ProductOrderAddVM> productOrders = new List<ProductOrderAddVM>();
            productOrders.Add(new ProductOrderAddVM() { ProductId = product.Id, Quantity = 1 });
            OrderAddVM orderModel = new OrderAddVM()
            {
                Table = "stolik Test",
                ProductOrders = productOrders
            };
            OrderController.Add(orderModel);

            Order order = OrderRepository.GetSingle(x => x.Table == "stolik Test");
            ProductOrder productOrder = ProductOrderRepository.GetSingle(x => x.ProductId == product.Id && x.OrderId == order.Id);

            OrderController.SetStatus(new OrderStatus() { OrderId = productOrder.Id });

            Order orderAfterSet = OrderRepository.GetSingle(x => x.Table == "stolik Test");
            ProductOrder productOrderAfterSet = ProductOrderRepository.GetSingle(x => x.ProductId == product.Id && x.OrderId == order.Id);

            Assert.That(orderAfterSet.OrderStatus, Is.EqualTo(OrderStatusEnum.Done));
            Assert.That(orderAfterSet.AppetizerStatus, Is.EqualTo(OrderStatusEnum.Done));
            Assert.That(productOrderAfterSet.Status, Is.EqualTo(OrderStatusEnum.Done));

        }

        [Test, Isolated]
        public void Set_Order_Status_Drinks_By_Controller_ShouldAddProductToDatabased()
        {

            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var model = new Product
            {
                Name = "name",
                Description = "Test",
                Image = arr1,
                ImageTumb = arr1,
                Price = 999,
                ProductType = ProductType.Drink,
                TimeOfPreparation = 999
            };
            ProductRepository.Add(model);
            ProductRepository.Save();
            Product product = ProductRepository.GetSingle(x => x.Name == "name" && x.Description == "Test");

            List<ProductOrderAddVM> productOrders = new List<ProductOrderAddVM>();
            productOrders.Add(new ProductOrderAddVM() { ProductId = product.Id, Quantity = 1 });
            OrderAddVM orderModel = new OrderAddVM()
            {
                Table = "stolik Test",
                ProductOrders = productOrders
            };
            OrderController.Add(orderModel);

            Order order = OrderRepository.GetSingle(x => x.Table == "stolik Test");
            ProductOrder productOrder = ProductOrderRepository.GetSingle(x => x.ProductId == product.Id && x.OrderId == order.Id);

            OrderController.SetStatusDrinks(new OrderStatusDrink() { OrderId = order.Id, ProductType = 4 });

            Order orderAfterSet = OrderRepository.GetSingle(x => x.Table == "stolik Test");
            ProductOrder productOrderAfterSet = ProductOrderRepository.GetSingle(x => x.ProductId == product.Id && x.OrderId == order.Id);

            Assert.That(orderAfterSet.OrderStatus, Is.EqualTo(OrderStatusEnum.Done));
            Assert.That(orderAfterSet.DrinksStatus, Is.EqualTo(OrderStatusEnum.Done));
            Assert.That(productOrderAfterSet.Status, Is.EqualTo(OrderStatusEnum.Done));
        }

    }
}