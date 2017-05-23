using System;
using System.Collections.Generic;

namespace DataVisualization.Models
{
  public class ParsedCode
  {
    public ParsedCode()
    {
      Packages = new List<Package>();
    }
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateParsed { get; set; }
    public List<Package> Packages { get; set; }
  }

  public class Package
  {
    public Package()
    {
      Connections = new List<string>();
    }
    public string ComponentName { get; set; }
    public List<string> Connections { get; set; }
  }
}