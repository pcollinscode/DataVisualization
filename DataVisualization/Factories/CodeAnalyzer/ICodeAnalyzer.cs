using DataVisualization.Models;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Factories.CodeAnalyzer
{
  public interface ICodeAnalyzer
  {
    DependencyWheel BuildDependencyWheel(ParsedData data);
    DependencyGroup BuildDependencyGroup(ParsedData data);
  }
}
