using System;
using System.Collections.Generic;

namespace DataVisualization.Models
{
  public class DependencyGroup
  {
    public string name { get; set; }
    public string datemodified { get; set; }
    public List<Children> children { get; set; }
  }

  public class Children
  {
    public string name { get; set; }
    public string datemodified { get; set; }
    public int? size { get; set; }
    public List<Children> children { get; set; }
  }
}