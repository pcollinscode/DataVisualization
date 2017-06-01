using DataVisualization.Models;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Factories
{
  public interface ICodeAnalyzer
  {
    DependencyWheel BuildDependencyWheel();
    JObject BuildDependencyGroup();
  }
}
