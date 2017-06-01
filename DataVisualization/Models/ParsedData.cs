using System.Collections.Generic;

namespace DataVisualization.Models
{
  public class ParsedData
  {
    public List<string> packageNames;
    public List<string> components;
    public List<string> connectors;
    public List<List<string>> connectorsArray;
  }
}