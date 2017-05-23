using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVisualization.Models;

namespace DataVisualization.Services
{
  /// <summary>
  /// Notifications that have come in to be processed.
  /// </summary>
  public interface INotifyAndUpdateService
  {
    IList<NotifyAndUpdateData> Get();
    NotifyAndUpdateData Get(int id);
    NotifyAndUpdateData Add(NotifyAndUpdateData data);
  }
}
