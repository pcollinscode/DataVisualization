using DataVisualization.Models;

namespace DataVisualization.Factories
{
  public interface ICodeAnalyzer
  {
    DependencyWheel BuilDependencyWheel();
    DependencyGroup BuilDependencyGroup();
  }
}
