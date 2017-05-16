using DataVisualization.Utilities;

namespace DataVisualization.Factories
{
  public class JavaCodeAnalyzer : ICodeAnalyzer
  {
    public string Analyze(string id)
    {
      return "analysis complete for '{0}'".FormatString(id);
    }
  }
}