using System;
using System.Collections.Generic;
using System.IO;
using DataVisualization.Models;
using DataVisualization.Repository;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Factories
{
  public class JavaCodeAnalyzer : ICodeAnalyzer
  {
    private readonly IVisualizationDataRepository _visualizationDataRepository;

    public JavaCodeAnalyzer(IVisualizationDataRepository visualizationDataRepository)
    {
      _visualizationDataRepository = visualizationDataRepository;
    }

    /// <summary>
    /// Analyze the parsed code data to create information for visualization
    /// </summary>
    /// <returns></returns>
    public DependencyWheel BuildDependencyWheel()
    {
      var data = _visualizationDataRepository.GetParsedCodeData();

      var wheel = new DependencyWheel
      {
        packageNames = data.packageNames.ToArray(),
        matrix = new int[data.components.Count][]
      };

      // build wheel's matrix
      for (var i = 0; i < data.components.Count; i++)
      {
        wheel.matrix[i] = new int[data.components.Count];
        for (var j = 0; j < data.components.Count; j++)
        {
          for (var k = 0; k < data.connectors.Count; k++)
          {
            // if source is equal to current row in the matrix
            if (data.connectorsArray[k][0].Equals(wheel.packageNames[i].ToLower()))
            {
              // if target is equal to the current column in matrix
              if (!data.connectorsArray[k][1].Equals(wheel.packageNames[j].ToLower()))
                continue;

              //give connection a true value
              wheel.matrix[i][j] = 1;
              k = data.connectors.Count;
            }
            else
              //if no connection give false value
              wheel.matrix[i][j] = 0;
          }
        }
      }

      return wheel;
    }
    /// <summary>
    /// Create object to display the dependency grouping from the parsed code data
    /// </summary>
    /// <returns></returns>
    public JObject BuildDependencyGroup()
    {
      //var data = _visualizationDataRepository.GetParsedCodeData();

      var file = AppDomain.CurrentDomain.BaseDirectory + @"Data\visualizationdata.json";
      var o = JObject.Parse(File.ReadAllText(file));

      return o;
    }
  }
}