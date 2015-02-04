using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcSiteMapProvider_345_2.EntityFramework
{
    public class Seeder : DropCreateDatabaseIfModelChanges<MyEntityContext>
    {
        protected override void Seed(MyEntityContext context)
        {
            SeedProduct(context);
            SeedCategory(context);
        }

        private void SeedProduct(MyEntityContext context)
        {
            int recordNumber = 1;
            int recordsPerFlush = 100;

            for (int j = 0; j < 160; j++)
            {
                for (int i = 1; i <= recordsPerFlush; i++)
                {
                    recordNumber = i + (j * recordsPerFlush);
                    context.Product.Add(new Product { Id = recordNumber, Name = "Product " + recordNumber.ToString(), LastUpdated = DateTime.UtcNow });
                }

                context.SaveChanges();
            }

        }

        private void SeedCategory(MyEntityContext context)
        {
            for (int i = 1; i <= 25; i++)
            {
                context.Category.Add(new Category { Id = i, Name = "Category " + i.ToString(), LastUpdated = DateTime.UtcNow });
            }

            context.SaveChanges();
        }
    }
}