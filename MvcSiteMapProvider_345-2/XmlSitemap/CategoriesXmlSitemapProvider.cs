using MvcSiteMapProvider.Xml.Sitemap;
using MvcSiteMapProvider.Xml.Sitemap.Specialized;
using System;
using System.Linq;

namespace MvcSiteMapProvider_345_2.XmlSitemap
{
    public class CategoriesXmlSitemapProvider : XmlSitemapProviderBase, IDisposable
    {
        private EntityFramework.MyEntityContext db = new EntityFramework.MyEntityContext();

        // This is optional. Don't override it if you don't want to use last modified date.
        public override DateTime GetLastModifiedDate(string feedName, int skip, int take)
        {
            // Get the latest date in the specified page
            return db.Category.OrderBy(x => x.Id).Skip(skip).Take(take).Max(c => c.LastUpdated);
        }

        public override int GetTotalRecordCount(string feedName)
        {
            // Get the total record count for all pages
            return db.Category.Count();
        }

        public override void GetUrlEntries(IUrlEntryHelper helper)
        {
            // Do not call ToList() on the query. The idea is that we want to force
            // EntityFramework to use a DataReader rather than loading all of the data
            // at once into RAM.
            var categories = db.Category
                .OrderBy(x => x.Id)
                .Skip(helper.Skip)
                .Take(helper.Take);

            foreach (var category in categories)
            {
                var entry = helper.BuildUrlEntry(string.Format("~/Category/{0}", category.Id))
                    .WithLastModifiedDate(category.LastUpdated)
                    .WithChangeFrequency(MvcSiteMapProvider.ChangeFrequency.Daily)
                    .AddContent(content => content.Image(string.Format("~/images/category-image-{0}.jpg", category.Id)).WithCaption(category.Name));

                helper.SendUrlEntry(entry);
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}