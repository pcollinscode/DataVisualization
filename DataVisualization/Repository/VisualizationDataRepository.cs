using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Repository
{
  public class VisualizationDataRepository : IVisualizationDataRepository
  {
    public JObject Get()
    {
      var file = AppDomain.CurrentDomain.BaseDirectory + @"Data\visualizationdata.json";

      var o = JObject.Parse(File.ReadAllText(file));

      return o;
    }
  }
}