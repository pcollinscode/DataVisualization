using System;
using System.Collections.Generic;
using System.Linq;
using DataVisualization.Models;

namespace DataVisualization.Factories.CodeParser
{
  public class JavaCodeParser : ICodeParser
  {
    public ParsedData Parse()
    {
            var components = new List<string>();
            var connectors = new List<string>();
            var packageNames = new List<string>();
            var connectorsArray = new List<List<string>>();

            var searchStrCom = "package=";
            var searchStrCon = "source=";
            var length = 3;
            string[] blackList = { "jersey", "jackson", "versioncheck", "web", "metrics", "audit", "configuration", "grok", "gettingstarted", "utilities", "timeranges",
                                    "rules", "bootstrap", "buffers", "bindings", "savedsearches", "shared", "log4j" };

            //This function parses out the components from fileName according to the searchStr and length parameter
            var scan = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Data\main.java.org.graylog2_UML.cdg");
            var i = 0;
            // pull out all components based on depth in java language
            while (i < scan.Length)
            {
                var line = scan[i].ToLower().ToString();
                var words = line.Split(' ');

                IList<string> list = words;

                IEnumerator<string> it1 = list.GetEnumerator();

                while (it1.MoveNext())
                {
                    var current = it1.Current.ToString();
                    // check if it contains the searchStr
                    if (current.Contains(searchStrCom))
                    {
                        var pack_length = current.Split('.');
                        // check that it is the correct depth
                        if (pack_length.Length == length)
                        {
                            var temp = pack_length[length-1].Split('"');
                            if (!blackList.Contains(temp[0]))
                            {
                                // check that it is not already in the list
                                if (!components.Contains(current))
                                {
                                    components.Add(current);
                                }
                            }
                        }
                    }
                }
                i++;
            }


            //This function parses out the connections from fileName according to the searchStr and length parameter
            scan = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Data\main.java.org.graylog2_UML.cdg");
            i = 0;

            // add one to find component connections
            length = length + 1;

            IList<string> connections = new List<string>();

            // pull out targets and sources from XML file
            while (i < scan.Length)
            {
                var line = scan[i].ToLower().ToString();
                var words = line.Split(' ');

                IList<string> list = words;

                IEnumerator<string> it2 = list.GetEnumerator();

                while (it2.MoveNext())
                {
                    var current = it2.Current.ToString();
                    // check if it contains the searchStr
                    if (current.Contains(searchStrCon))
                    {
                        var pack_length = current.Split('.');
                        // check that it is the correct depth
                        if (pack_length.Length == length)
                        {
                            // check that it is not already in the list
                            if (!connections.Contains(current))
                            {
                                it2.MoveNext();
                                connections.Add(current + ":" + it2.Current.ToString());
                            }
                        }
                    }
                }
                i++;
            }

            IEnumerator<string> it = connections.GetEnumerator();

            // build global connectors list from extracted sources and targets
            while (it.MoveNext())
            {
                var temp = it.Current.ToString().Split(':');
                var source = temp[0].Split('.');
                var target = temp[1].Split('.');
                var connection = "";

                // check to make sure the connection is not to itself
                if (source[(int)length - 2] != target[(int)length - 2])
                {
                    //rebuild source address using only the component
                    for (var j = 0; j < length - 1; j++)
                    {
                        connection = connection + source[j];
                        if (j < length - 2)
                        {
                            connection = connection + ".";
                        }
                        else
                        {
                            connection = connection + "\"";
                        }
                    }

                    // used to delineate between source and target
                    connection = connection + "|";

                    //rebuild target address using only the component
                    for (var j = 0; j < length - 1; j++)
                    {
                        connection = connection + target[j];
                        if (j < length - 2)
                        {
                            connection = connection + ".";
                        }
                        else
                        {
                            connection = connection + "\"";
                        }
                    }

                    // if this connections doesn't exist add to the global list
                    if (!connectors.Contains(connection))
                    {
                        connectors.Add(connection);
                    }

                }

            }

            // iterators for components and connectors
            using (IEnumerator<string> comIt = components.GetEnumerator())
            {
                // place component names in packageNames
                for (i = 0; i < components.Count; i++)
                {
                    comIt.MoveNext();
                    var namespaces = comIt.Current.Split('.');
                    // use the last namespace as the component name and remove "
                    var temp = namespaces[namespaces.Length - 1].Split('"');
                    packageNames.Add(temp[0].ToUpper());
                }
            }

            using (IEnumerator<string> conIt = connectors.GetEnumerator())
            {
                //new 2d connectors string array
                for (i = 0; i < connectors.Count; i++)
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