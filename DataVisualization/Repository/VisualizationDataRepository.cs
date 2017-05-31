using System;
using System.IO;
using DataVisualization.Models;
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

    public JObject GetById(int id)
    {
      string file;
      JObject o = null;

      switch (id)
      {
        case 1:
          file = AppDomain.CurrentDomain.BaseDirectory + @"Data\visualizationdata.json";
          o = JObject.Parse(File.ReadAllText(file));
          break;
        case 2:
          file = AppDomain.CurrentDomain.BaseDirectory + @"Data\visualizationdata_wheel.json";
          o = JObject.Parse(File.ReadAllText(file));
          break;
        case 3:
          o = JObject.FromObject(GetWheel());
          break;
        default:
          throw new ArgumentException("Unknown id");
      }

      return o;
    }

    DependencyWheel GetWheel()
    {
      var wheel = new DependencyWheel
      {
        packageNames = new[] { "Main", "A", "B", "C" },
        matrix = new[]
        {
          new[] {0, 1, 1, 1},
          new[] {0, 0, 1, 1},
          new[] {0, 0, 0, 1},
          new[] {0, 0, 0, 0}
        }
      };


      return wheel;
    }
  }
}