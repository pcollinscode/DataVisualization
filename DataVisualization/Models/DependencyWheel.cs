using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataVisualization.Models
{
  public class DependencyWheel
  {
    public string[] packageNames { get; set; }
    public int[][] matrix { get; set; }
  }
}