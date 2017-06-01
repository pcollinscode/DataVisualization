using System;
using System.IO;
using DataVisualization.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
      JObject o;

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

    private static DependencyWheel GetWheel()
    {
      var components = new List<string>();
      var connectors = new List<string>();

      var scan = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Data\code_parse_example.txt");

      for (var i = 0; i < 41; i++)  // 0-40 components
        components.Add(scan[i]);
      for (var i = 41; i < 190; i++) // 41-189 is connectors
        connectors.Add(scan[i]);

      //****************************************
      // from here and above can be replaced with call to get component and connector lists
      //****************************************

      // create empty DependencyWheel
      var wheel = new DependencyWheel
      {
        packageNames = new string[components.Count],
        matrix = new int[components.Count][]
      };

      // iterators for components and connectors
      using (IEnumerator<string> comIt = components.GetEnumerator())
      {
        // place component names in packageNames
        for (var i = 0; i < components.Count; i++)
        {
          comIt.MoveNext();
          var namespaces = comIt.Current.Split('.');
          // use the last namespace as the component name and remove "
          var temp = namespaces[namespaces.Length - 1].Split('"');
          wheel.packageNames[i] = temp[0].ToUpper();
        }
      }

      using (IEnumerator<string> conIt = connectors.GetEnumerator())
      {
        //new 2d connectors string array
        var connectorsArray = new string[connectors.Count][];
        for (var i = 0; i < connectors.Count; i++)
        {
          conIt.MoveNext();
          //separate source and target
          var sourceTarget = conIt.Current.Split('|');
          //separate namespaces
          var source = sourceTarget[0].Split('.');
          var target = sourceTarget[1].Split('.');
          //remove " on the last element of namespace
          var tempSource = source[source.Length - 1].Split('"');
          var tempTarget = target[target.Length - 1].Split('"');
          //place only the last namespace name into the connectors array
          connectorsArray[i] = new[] { tempSource[0], tempTarget[0] };
        }

        // build wheel's matrix
        for (var i = 0; i < components.Count; i++)
        {
          wheel.matrix[i] = new int[components.Count];
          for (var j = 0; j < components.Count; j++)
          {
            for (var k = 0; k < connectors.Count; k++)
            {
              // if source is equal to current row in the matrix
              if (connectorsArray[k][0].Equals(wheel.packageNames[i].ToLower()))
              {
                // if target is equal to the current column in matrix
                if (!connectorsArray[k][1].Equals(wheel.packageNames[j].ToLower()))
                  continue;

                //give connection a true value
                wheel.matrix[i][j] = 1;
                k = connectors.Count;
              }
              else
                //if no connection give false value
                wheel.matrix[i][j] = 0;
            }
          }
        }
      }

      return wheel;
    }
  }
}