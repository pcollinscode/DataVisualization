using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataVisualization.Models
{
  public class ParsedDocumentation
  {
    public ParsedDocumentation()
    {
      PageDatas = new List<PageData>();
    }
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string ProjectUrl { get; set; }
    public List<PageData> PageDatas { get; set; }
  }

  public class PageData
  {
    public PageData()
    {
      word_counts = new Dictionary<string, int>();
    }
    public string Url { get; set; }
    public int UrlNumber { get; set; }
    public Dictionary<string, int> word_counts { get; set; }
  }
}