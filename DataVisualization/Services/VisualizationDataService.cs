using System;
using DataVisualization.Factories;
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

    public VisualizationData Get()
    {
      throw new NotImplementedException();
    }

    public VisualizationData GetById(int id)
    {
      var javaAnalyzer = _codeAnalyzerFactory.CreateCodeAnalyzer<JavaCodeAnalyzer>();
      var javaParser = _codeParserFactory.CreateCodeParser<JavaCodeParser>();

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