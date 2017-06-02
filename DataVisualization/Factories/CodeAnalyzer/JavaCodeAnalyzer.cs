using System;
using System.Collections.Generic;
using System.Linq;
using DataVisualization.Models;
using DataVisualization.Repository;

namespace DataVisualization.Factories.CodeAnalyzer
{
  public class JavaCodeAnalyzer : ICodeAnalyzer
  {
    private readonly IVisualizationDataRepository _visualizationDataRepository;
    private readonly Random _rand;

    public JavaCodeAnalyzer(IVisualizationDataRepository visualizationDataRepository)
    {
      _visualizationDataRepository = visualizationDataRepository;
      _rand = new Random();
    }

    /// <summary>
    /// Analyze the parsed code data to create information for visualization
    /// </summary>
    /// <returns></returns>
    public DependencyWheel BuildDependencyWheel(ParsedData data)
    {
      if (data == null)
      {
        data = _visualizationDataRepository.GetParsedCodeData();
      }

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
    public DependencyGroup BuildDependencyGroup(ParsedData data)
    {
      if (data == null)
      {
        data = _visualizationDataRepository.GetParsedCodeData();
      }

      var result = new DependencyGroup
      {
        name = "graylog",
        datemodified = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
        children = new List<Children>()
      };


      foreach (var t in data.packageNames)
      {
        result.children.Add(new Children
        {
          name = t.Trim(),
          size = null,
          datemodified = RandomDateTime(),
          children = new List<Children>()
        });
      }

      foreach (var child in result.children)
      {
        var matching = data.connectorsArray.Where(x => x[0].ToLower() == child.name.ToLower());

        foreach (var match in matching)
        {
          child.children.Add(new Children
          {
            children = null,
            datemodified = RandomDateTime(),
            name = match[1],
            size = 1
          });
        }
      }

      return result;
    }

    private string RandomDateTime()
    {
      var randDate = _rand.Next(0, 400) * -1;

      //subtract days
      var date = DateTime.UtcNow.AddDays(randDate).ToString("yyyy-MM-dd HH:mm:ss.fff");

      return date;
    }
  }
}