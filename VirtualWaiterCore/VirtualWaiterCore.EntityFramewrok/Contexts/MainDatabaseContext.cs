using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualWaiterCore.EntityFramework
{
    public class MainDatabaseContext : DbContext
    {
        public IConfiguration Configuration { get; set; }

        public MainDatabaseContext()
            : base()
        {
            Id = Guid.NewGuid(); 
        }


        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options)
            : base(options)
        {
            Id = Guid.NewGuid();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MainDatabaseContext"));
            }
        }

        public Guid Id { get; set; }

        public static MainDatabaseContext Create()
        {
            return (new AppContextFactory()).CreateDbContext(new string[0]);
        }

        //Add-Migration -Context MainDatabaseContext -o MainDatabaseMigrations <Nazwa migracji>
        //Update-Database -Context MainDatabaseContext
        //Remove-Migration -Context MainDatabaseContext

        #region Core
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Functionality> Functionalities { get; set; }
        public DbSet<FunctionalityAppRole> FunctionalityAppRoles { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        #endregion Core

        #region Order
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Appetizer> Appetizers { get; set; }
        public DbSet<MainCourse> MainCourses { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion Order

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Membership
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionalityAppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionalityConfiguration());
            #endregion Membership
        }
    }
}
