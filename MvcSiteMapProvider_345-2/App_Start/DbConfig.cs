using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcSiteMapProvider_345_2
{
    public class DbConfig
    {
        public static void Register()
        {
            // TODO: Remove the initializer before deploying to production
            Database.SetInitializer(new EntityFramework.Seeder());
        }
    }
}