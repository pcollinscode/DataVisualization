using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataVisualization.Models;

namespace DataVisualization.Services
{
  public class NotifyAndUpdateService : INotifyAndUpdateService
  {
    private readonly NotifyAndUpdateData one;
    private readonly NotifyAndUpdateData two;

    public NotifyAndUpdateService()
    {
      one = new NotifyAndUpdateData
      {
        id = 1,
        action = "released",
        repository = new Models.Repository
        {
          id = 123456,
          fullname = "ourrepo/dataviz",
          name = "dataviz"
        }
      };

      two = new NotifyAndUpdateData
      {
        id = 2,
        action = "released",
        repository = new Models.Repository
        {
          id = 892813,
          fullname = "theirrepo/tracker",
          name = "tracker"
        }
      };
    }

    public IList<NotifyAndUpdateData> Get()
    {
      return new List<NotifyAndUpdateData>
      {
        one,
        two
      };
    }

    public NotifyAndUpdateData Get(int id)
    {
      if (id == 1)
      {
        return one;
      }

      if (id == 2)
      {
        return two;
      }

      throw new ArgumentException("Could not find resource");
    }

    public NotifyAndUpdateData Add(NotifyAndUpdateData data)
    {
      data.id = 1;

      return data;
    }
  }
}