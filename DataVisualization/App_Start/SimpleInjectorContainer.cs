using System.Data.Entity.Infrastructure;
using System.Web.Http;
using DataVisualization.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace DataVisualization
{
  public class SimpleInjectorContainer
  {
    public static void Configure(HttpConfiguration config)
    {
      var container = new Container();

      //services

      //repositories
      container.Register<IParsedCodeRepository, ParsedCodeRepository>();

      config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
    }
  }
}