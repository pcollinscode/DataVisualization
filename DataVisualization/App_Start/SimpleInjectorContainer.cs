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

      container.Register<ICodeParserFactory, SimpleInjectorCodeParserFactory>();
      container.Register<JavaCodeParser>();

      //services
      container.Register<INotifyAndUpdateService, NotifyAndUpdateService>();
      container.Register<IVisualizationDataService, VisualizationDataService>();

      //repositories
      container.Register<IParsedCodeRepository, ParsedCodeRepository>();
      container.Register<IParsedDocumentationRepository, ParsedDocumentationRepository>();
      container.Register<IVisualizationDataRepository, VisualizationDataRepository>();

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

  internal class SimpleInjectorCodeParserFactory : ICodeParserFactory
  {
    private readonly Container _container;

    public SimpleInjectorCodeParserFactory(Container container)
    {
      _container = container;
    }

    public T CreateCodeParser<T>() where T : class, ICodeParser
    {
      return _container.GetInstance<T>();
    }
  }
}