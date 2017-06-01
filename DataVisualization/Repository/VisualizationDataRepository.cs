using System;
using System.IO;
using DataVisualization.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataVisualization.Repository
{
  public class VisualizationDataRepository : IVisualizationDataRepository
  {
    /// <summary>
    /// Return the data parsed from the code
    /// </summary>
    /// <returns></returns>
    public ParsedData GetParsedCodeData()
    {
      var components = new List<string>();
      var connectors = new List<string>();
      var packageNames = new List<string>();
      var connectorsArray = new List<List<string>>();

      var scan = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Data\code_parse_example.txt");

      for (var i = 0; i < 41; i++) // 0-40 components
        components.Add(scan[i]);
      for (var i = 41; i < 190; i++) // 41-189 is connectors
        connectors.Add(scan[i]);

      //****************************************
      // from here and above can be replaced with call to get component and connector lists
      //****************************************

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
          packageNames.Add(temp[0].ToUpper());
          //packageNames[i] = temp[0].ToUpper();
        }
      }

      using (IEnumerator<string> conIt = connectors.GetEnumerator())
      {
        //new 2d connectors string array

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
          connectorsArray.Add(new List<string> { tempSource[0], tempTarget[0] });
          //connectorsArray[i] = new[] { tempSource[0], tempTarget[0] };
        }
      }

      return new ParsedData
      {
        components = components,
        connectors = connectors,
        packageNames = packageNames,
        connectorsArray = connectorsArray
      };
    }
  }
}