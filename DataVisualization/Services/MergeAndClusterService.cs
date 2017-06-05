using System;
using DataVisualization.Models;
using DataVisualization.Repository;

namespace DataVisualization.Services
{
  public class MergeAndClusterService : IMergeAndClusterService
  {
    private readonly IMergeAndClusterRepository _mergeAndClusterRepository;

    public MergeAndClusterService(IMergeAndClusterRepository mergeAndClusterRepository)
    {
      _mergeAndClusterRepository = mergeAndClusterRepository;
    }

    public MergedAndClusteredData MergedAndCluster()
    {
      var mergedData = new MergedAndClusteredData();

      var created = _mergeAndClusterRepository.Add(mergedData);

      return created;
    }
  }
}