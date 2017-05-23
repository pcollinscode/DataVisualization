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
      Source = new List<string>();
    }
    public string PackageName { get; set; }
    public List<string> Source { get; set; }
  }
}