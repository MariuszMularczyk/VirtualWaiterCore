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
            builder.RegisterType<DrinkService>().As<IDrinkService>();
            builder.RegisterType<DrinkRepository>().As<IDrinkRepository>();

            builder.RegisterType<DessertService>().As<IDessertService>();
            builder.RegisterType<DessertRepository>().As<IDessertRepository>();

            builder.RegisterType<AppetizerService>().As<IAppetizerService>();
            builder.RegisterType<AppetizerRepository>().As<IAppetizerRepository>();

            builder.RegisterType<MainCourseService>().As<IMainCourseService>();
            builder.RegisterType<MainCourseRepository>().As<IMainCourseRepository>();
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
