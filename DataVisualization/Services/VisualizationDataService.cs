using DataVisualization.Factories.CodeAnalyzer;
using DataVisualization.Factories.CodeParser;
using DataVisualization.Models;

namespace DataVisualization.Services
{
  public class VisualizationDataService : IVisualizationDataService
  {
    private readonly ICodeAnalyzerFactory _codeAnalyzerFactory;
    private readonly ICodeParserFactory _codeParserFactory;

    public VisualizationDataService(ICodeAnalyzerFactory codeAnalyzerFactory, ICodeParserFactory codeParserFactory)
    {
      _codeAnalyzerFactory = codeAnalyzerFactory;
      _codeParserFactory = codeParserFactory;
    }

    public VisualizationData ParseAndAnalyze<TParse, TAnalyze>()
      where TParse : class, ICodeParser
      where TAnalyze : class, ICodeAnalyzer
    {
      var javaAnalyzer = _codeAnalyzerFactory.CreateCodeAnalyzer<TAnalyze>();
      var javaParser = _codeParserFactory.CreateCodeParser<TParse>();

      var data = javaParser.Parse();
      var dependencyGroup = javaAnalyzer.BuildDependencyGroup(data);
      var dependencyWheel = javaAnalyzer.BuildDependencyWheel(data);

      return new VisualizationData
      {
        DependencyGroup = dependencyGroup,
        DependencyWheel = dependencyWheel
      };
    }
  }
}