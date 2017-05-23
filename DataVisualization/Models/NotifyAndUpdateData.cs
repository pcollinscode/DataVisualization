using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace DataVisualization.Models
{
  /// <summary>
  /// Requires github webhook to be created. Or any other third party api.
  /// This is the data that comes from the even hook from github api
  /// </summary>
  public class NotifyAndUpdateData
  {
    public NotifyAndUpdateData()
    {
      repository = new Repository();
    }
    public int id { get; set; }
    public string action { get; set; }
    public Repository repository { get; set; }
  }

  public class Repository
  {
    public int id { get; set; }
    public string name { get; set; }
    public string fullname { get; set; }
  }
}