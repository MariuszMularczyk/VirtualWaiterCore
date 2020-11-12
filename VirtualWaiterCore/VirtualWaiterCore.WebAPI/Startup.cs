using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Autofac;
using VirtualWaiterCore.EntityFramework;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using VirtualWaiterCore.Infrastructure;

namespace VirtualWaiterCore.WebAPI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<MainDatabaseContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MainDatabaseContext")));
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // This will all go in the ROOT CONTAINER and is NOT TENANT SPECIFIC.IDrinkRepository

            builder.RegisterType<MainContext>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<TransactionInterceptor>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<DbSession>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();

            builder.Register(context => MainDatabaseContext.Create()).As<MainDatabaseContext>().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<TransactionInterceptor>().InstancePerLifetimeScope();


            builder.RegisterType<ProductService>().As<IProductService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<ProductService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<ProductRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();

            builder.RegisterType<OrderService>().As<IOrderService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<OrderService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<OrderRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<ProductOrderRepository>().As<IProductOrderRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<ProductOrderRepository>().As<ProductOrderRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDatabaseContext db)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
