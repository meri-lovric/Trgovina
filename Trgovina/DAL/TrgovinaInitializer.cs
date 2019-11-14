using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trgovina.Models;
namespace Trgovina.DAL
{
    public class TrgovinaInitializer : DropCreateDatabaseAlways<TrgovinaContext>
    {
       protected override void Seed(TrgovinaContext context)
        {
            var stores = new List<Store>()
            {
                new Store(){ storeName = "Konzum"},
                new Store(){ storeName = "Tommy"},
                new Store(){ storeName = "Studenac"}

            };
            var products = new List<Product>()
            {
                new Product(){ productName ="Jabuka", quantity = 10, Store = stores[0]},
                new Product(){ productName ="Kruska", quantity = 15,Store = stores[1] },
                new Product(){ productName ="Banana", quantity = 20, Store = stores[2] },
                new Product(){ productName ="Šljive", quantity = 20, Store = stores[2] },
                new Product(){ productName ="Naranče", quantity = 20, Store = stores[1] },
                new Product(){ productName ="Mandarine", quantity = 20, Store = stores[1] }

            };
            context.Stores.AddRange(stores);
            context.Products.AddRange(products);

            context.SaveChanges();

        }
    }
}