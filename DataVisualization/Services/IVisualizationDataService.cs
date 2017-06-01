using DataVisualization.Models;

namespace DataVisualization.Services
{
  public interface IVisualizationDataService
  {
    VisualizationData Get();
    VisualizationData GetById(int id);
  }
}
