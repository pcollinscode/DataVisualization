using DataVisualization.Models;

namespace DataVisualization.Services
{
  /// <summary>
  /// Notifications that have come in to be processed.
  /// </summary>
  public interface INotifyAndUpdateService
  {
    NotifyAndUpdateData GetById(int id);
    NotifyAndUpdateData Add(NotifyAndUpdateData data);
  }
}
