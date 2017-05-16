using System;
using System.Web.Http;
using System.Web.Http.Cors;
using DataVisualization;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(Startup))]

namespace DataVisualization
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();
      // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
      ConfigureWebApi(app, config);

      SimpleInjectorContainer.Configure(config);
    }
    private static void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
    {
      app.Map("/api", a =>
      {
        //allow full cross origin requests for now
        config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

        //turn on swagger for auto documentation
        config.EnableSwagger(c =>
        {
          c.SingleApiVersion("v1", "DataVisualization");
          c.RootUrl(r => r.RequestUri.GetLeftPart(UriPartial.Authority) + "/api");
        })
        .EnableSwaggerUi(c =>
        {

        });

        //use the mapping configured per resource
        config.MapHttpAttributeRoutes();

        //tell the middleware we are using web api
        a.UseWebApi(config);
      });
    }
  }
}
