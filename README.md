# MvcSiteMapProvider_345-2
A demo project showing how to use a pre-alpha release of the new XML sitemap functionality (for search engines).

> **Important:** To use the new XML sitemap functionality, you must disable the old functionality. We are planning to leave the old functionality in place for backward compatibility with existing DI configurations.

If using internal DI, you should set the web.config setting:

```xml
<add key="MvcSiteMapProvider_EnableSitemapsXml" value="false"/>
```

For external DI, you need to ensure the following line is removed (or commented) from your application startup:

```csharp
// Register the XML sitemap routes for search engines
XmlSiteMapController.RegisterRoutes(RouteTable.Routes);
```
