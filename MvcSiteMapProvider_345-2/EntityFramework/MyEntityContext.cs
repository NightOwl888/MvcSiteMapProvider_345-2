using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcSiteMapProvider_345_2.EntityFramework
{
    public class MyEntityContext : DbContext
    {
        // Database Schema
        public IDbSet<Product> Product { get; set; }
        public IDbSet<Category> Category { get; set; }
    }
}