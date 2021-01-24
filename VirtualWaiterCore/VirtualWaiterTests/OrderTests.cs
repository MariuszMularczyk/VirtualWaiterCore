using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.IO;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.WebAPI;

namespace VirtualWaiterTests
{
    public class OrderTests
    {

        private static DbContextOptions<MainDatabaseContext> _options;

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

        }
        [Test, Isolated]
        public void Get_Orders_ShouldBeOrdered()
        {

            var context = new MainDatabaseContext(_options);

            var productRepository = new OrderRepository(context);
            var list = productRepository.GetOrders();
            if(list.Count > 0)
            {
                decimal time;
                foreach(var element in list)
                {
                    time = element.TimeOfPreparations[0];
                    foreach (decimal timeOfPreparation in element.TimeOfPreparations)
                    {
                        
                        Assert.That(timeOfPreparation, Is.LessThanOrEqualTo(time));
                        time = timeOfPreparation;
                    }
                }

            }
            else
            {
                Assert.True(true);
            }

        }

      

    }
}