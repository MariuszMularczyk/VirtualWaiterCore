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
using VirtualWaiterCore.WebAPI.Controllers;

namespace VirtualWaiterTests
{
    public class AppTests
    {

        private static DbContextOptions<MainDatabaseContext> _options;
        private ProductRepository ProductRepository { get; set;  }
        private ProductService ProductService { get; set; }
        private AppetizerController AppetizerController { get; set; }
        private MainDatabaseContext Context { get; set; }
        public AppTests()
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
            ProductRepository = new ProductRepository(Context);
            ProductService = new ProductService(ProductRepository);
            AppetizerController = new AppetizerController(ProductService);

            Assert.That(AppetizerController, !Is.Null);
            Assert.That(ProductService, !Is.Null);
            Assert.That(ProductRepository, !Is.Null);
            Assert.That(Context, !Is.Null);
            Assert.That(_options, !Is.Null);
        }
        [Test, Isolated]
        public void Check_Injections()
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
            ProductRepository = new ProductRepository(Context);
            ProductService = new ProductService(ProductRepository);
            AppetizerController = new AppetizerController(ProductService);

            Assert.That(AppetizerController, !Is.Null);
            Assert.That(ProductService, !Is.Null);
            Assert.That(ProductRepository, !Is.Null);
            Assert.That(Context, !Is.Null);
            Assert.That(_options, !Is.Null);

        }
        [Test, Isolated]
        public void Check_Converter()
        {
            AppSettingConverter converter = new AppSettingConverter();
            AppSettingAddVM appRoleAddVM = new AppSettingAddVM()
            {
                Value = "3",
                Type = AppSettingEnum.NumberOfCooks
            };
            AppSetting appSetting = converter.FromAppSettingAddVM(appRoleAddVM);
            Assert.That(appSetting.Value, Is.EqualTo("3"));
            Assert.That(appSetting.Type, Is.EqualTo(AppSettingEnum.NumberOfCooks));
        }




    }
}