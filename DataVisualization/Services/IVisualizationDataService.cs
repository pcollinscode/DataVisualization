using DataVisualization.Factories.CodeAnalyzer;
using DataVisualization.Factories.CodeParser;
using DataVisualization.Models;

namespace DataVisualization.Services
{
  public interface IVisualizationDataService
  {
    VisualizationData ParseAndAnalyze<TParse, TAnalyze>()
      where TParse : class, ICodeParser
      where TAnalyze : class, ICodeAnalyzer;
  }
}
