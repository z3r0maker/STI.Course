using Microsoft.EntityFrameworkCore;
using STI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace STI.Data
{
    public class STIContext : DbContext
    {
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseType> WarehouseType { get; set; }

        public DbSet<Company> Company { get; set; }
        //public DbSet<User> Warehouse { get; set; }



        public STIContext(DbContextOptions<STIContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
              .Where(x => x.GetInterfaces().Any(type =>
                  type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
              .ToList();

            //Get all the IEntityTypeConfiguration and execute the HasData()
            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
                var entityType = type.GetGenericInterfaceParameter(typeof(IEntityTypeConfiguration<>));
                modelBuilder.Entity(entityType).HasData();
            }
            base.OnModelCreating(modelBuilder);
        }
    }

    public static class TypeExtensions
    {
        public static Type GetGenericInterfaceParameter(this Type concreteType, Type interfaceType)
        {
            var _interface = concreteType
                .GetInterfaces()
                .Single(y => y.IsGenericType && y.GetGenericTypeDefinition() == interfaceType);

            return _interface.GetGenericArguments().First();
        }
    }
}
