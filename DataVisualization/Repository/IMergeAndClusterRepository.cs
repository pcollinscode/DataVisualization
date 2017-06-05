using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public interface IMergeAndClusterRepository
  {
    MergedAndClusteredData Add(MergedAndClusteredData data);
  }
}
