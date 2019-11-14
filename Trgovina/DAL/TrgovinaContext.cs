using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trgovina.Models;
namespace Trgovina.DAL
{
    public class TrgovinaContext : DbContext
    {
        public DbSet<Store>  Stores { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}