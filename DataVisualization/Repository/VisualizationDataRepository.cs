using System;
using System.IO;
using DataVisualization.Models;
using Newtonsoft.Json.Linq;

//added for dependency wheel
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<string> components = new List<string>();
            List<string> connectors = new List<string>();

            string[] scan = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Data\code_parse_example.txt");

            for (int i = 0; i < 41; i++)  // 0-40 components
                components.Add(scan[i]);
            for (int i = 41; i < 190; i++) // 41-189 is connectors
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
            IEnumerator<string> comIt = components.GetEnumerator();
            IEnumerator<string> conIt = connectors.GetEnumerator();

            // place component names in packageNames
            for (int i = 0; i < components.Count; i++)
            {
                comIt.MoveNext();
                string[] namespaces = comIt.Current.ToString().Split('.');
                // use the last namespace as the component name and remove "
                string[] temp = namespaces[namespaces.Count() - 1].Split('"');
                wheel.packageNames[i] = temp[0].ToUpper();
            }

            //new 2d connectors string array
            string[][] connectors_array = new string[connectors.Count][];
            for (int i = 0; i < connectors.Count; i++)
            {
                conIt.MoveNext();
                //separate source and target
                string[] source_target = conIt.Current.ToString().Split('|');
                //separate namespaces
                string[] source = source_target[0].Split('.');
                string[] target = source_target[1].Split('.');
                //remove " on the last element of namespace
                string[] tempSource = source[source.Count() - 1].Split('"');
                string[] tempTarget = target[target.Count() - 1].Split('"');
                //place only the last namespace name into the connectors array
                connectors_array[i] = new[] { tempSource[0], tempTarget[0] };
            }

            // build wheel's matrix
            for (int i = 0; i < components.Count; i++)
            {
                wheel.matrix[i] = new int[components.Count];
                for (int j = 0; j < components.Count; j++)
                {
                    for (int k = 0; k < connectors.Count; k++)
                    {
                        // if source is equal to current row in the matrix
                        if (connectors_array[k][0].Equals(wheel.packageNames[i].ToLower()))
                        {
                            // if target is equal to the current column in matrix
                            if (connectors_array[k][1].Equals(wheel.packageNames[j].ToLower()))
                            {
                                //give connection a true value
                                wheel.matrix[i][j] = 1;
                                k = connectors.Count;
                            }
                        }
                        else
                            //if no connection give false value
                            wheel.matrix[i][j] = 0;
                    }
                }
            }

      return wheel;
    }
  }
}