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
    public class ProductTests
    {

        private static DbContextOptions<MainDatabaseContext> _options;

        public ProductTests()
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
        public void Add_Product_ShouldAddProductToDatabase()
        {

            var context = new MainDatabaseContext(_options);
            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var user = new Product
            {
                Name = "name",
                Description = "Test",
                Image = arr1,
                ImageTumb = arr1,
                Price = 999,
                ProductType = ProductType.Appetizer,
                TimeOfPreparation = 999
            };

            var productRepository = new ProductRepository(context);
            var listBeforeAdd = productRepository.GetAllToMenu(ProductType.Appetizer);
            productRepository.Add(user);
            productRepository.Save();
            var listAfterAdd = productRepository.GetAllToMenu(ProductType.Appetizer);

            Assert.That(listAfterAdd.Count, Is.EqualTo(listBeforeAdd.Count + 1));

        }
        [Test, Isolated]
        public void Edit_Product_ShouldEditProductToDatabase()
        {
          /*  using (var mock = AutoMock.GetLoose())
            {
                // The AutoMock class will inject a mock IStudyLoader
                // into the StudyLoader constructor
                //no need to create/configure a container
                var studyLoader = mock.Create<ProductService>();
            }*/
            
            var context = new MainDatabaseContext(_options);
            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var user = new Product
            {
                Name = "name",
                Description = "Test",
                Image = arr1,
                ImageTumb = arr1,
                Price = 999,
                ProductType = ProductType.Appetizer,
                TimeOfPreparation = 999
            };

            var productRepository = new ProductRepository(context);
            var listBeforeAdd = productRepository.GetAllToMenu(ProductType.Appetizer);
            productRepository.Add(user);
            productRepository.Save();
            var listAfterAdd = productRepository.GetAllToMenu(ProductType.Appetizer);

            Assert.That(listAfterAdd.Count, Is.EqualTo(listBeforeAdd.Count + 1));
            
        }

        [Test, Isolated]
        public void AddProductByService_ShouldAddProductToDatabase()
        {

            var context = new MainDatabaseContext(_options);
            byte[] arr1 = { 0, 100, 120, 210, 255 };
            var user = new ProductAddVM
            {
                Name = "name",
                Description = "Test",
                Image = "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",
                Price = 999,
                TimeOfPreparation = 999
            };
            IProductRepository productRepository = new ProductRepository(context);
            var producService = new ProductService(productRepository);
            var listBeforeAdd = producService.GetProducts(ProductType.Appetizer);
            producService.Add(user, ProductType.Appetizer);
            var listAfterAdd = producService.GetProducts(ProductType.Appetizer);

            Assert.That(listAfterAdd.Count, Is.EqualTo(listBeforeAdd.Count + 1));

        }

    }
}