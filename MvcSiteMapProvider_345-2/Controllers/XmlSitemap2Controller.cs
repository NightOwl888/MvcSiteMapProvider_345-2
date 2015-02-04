using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MvcSiteMapProvider.IO;
using MvcSiteMapProvider.Reflection;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Xml.Sitemap;
using MvcSiteMapProvider.Xml.Sitemap.Configuration;

namespace MvcSiteMapProvider_345_2.Controllers
{
    public class XmlSitemap2Controller : Controller
    {
        private readonly IXmlSitemapFeedResultFactory xmlSitemapFeedResultFactory;

        public XmlSitemap2Controller()
        {
            var builder = new XmlSitemapFeedStrategyBuilder();

            var xmlSitemapFeedStrategy = builder
                .SetupXmlSitemapProviderScan(scan => scan.IncludeAssembly(this.GetType().Assembly))
                .AddNamedFeed("default", feed => feed.WithMaximumPageSize(5000).WithContent(content => content.Image().Video()))
                .Create();

            var outputCompressor = new HttpResponseStreamCompressor();

            this.xmlSitemapFeedResultFactory = new XmlSitemapFeedResultFactory(xmlSitemapFeedStrategy, outputCompressor);
        }

        public ActionResult Index(int page = 0, string feedName = "")
        {
            var name = string.IsNullOrEmpty(feedName) ? "default" : feedName;
            return this.xmlSitemapFeedResultFactory.Create(page, name);
        }
    }
}
