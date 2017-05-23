using System.Web.Http;
using DataVisualization.Factories;
using DataVisualization.Repository;
using DataVisualization.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace DataVisualization
{
  public class SimpleInjectorContainer
  {
    public static void Configure(HttpConfiguration config)
    {
      var container = new Container();
      
      //factories
      container.Register<ICodeAnalyzerFactory, SimpleInjectorCodeAnalyzerFactory>();
      container.Register<JavaCodeAnalyzer>();

      //services
      container.Register<INotifyAndUpdateService, NotifyAndUpdateService>();

      //repositories
      container.Register<IParsedCodeRepository, ParsedCodeRepository>();

      config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
    }
  }

  internal class SimpleInjectorCodeAnalyzerFactory : ICodeAnalyzerFactory
  {
    private readonly Container _container;

    public SimpleInjectorCodeAnalyzerFactory(Container container)
    {
      _container = container;
    }

    public T CreateCodeAnalyzer<T>() where T : class, ICodeAnalyzer
    {
      return _container.GetInstance<T>();
    }
  }
}