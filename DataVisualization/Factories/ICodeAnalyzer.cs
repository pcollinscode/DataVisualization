using DataVisualization.Models;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Factories
{
  public interface ICodeAnalyzer
  {
    DependencyWheel BuildDependencyWheel(ParsedData data);
    JObject BuildDependencyGroup(ParsedData data);
  }
}
