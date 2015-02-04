using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSiteMapProvider_345_2.EntityFramework
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}