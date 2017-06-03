using System;
using DataVisualization.Factories.CodeAnalyzer;
using DataVisualization.Factories.CodeParser;
using DataVisualization.Models;

namespace DataVisualization.Services
{
  public class NotifyAndUpdateService : INotifyAndUpdateService
  {
    private readonly IVisualizationDataService _visualizationDataService;
    private readonly IMergeAndClusterService _mergeAndClusterService;

    public NotifyAndUpdateService(IVisualizationDataService visualizationDataService, IMergeAndClusterService mergeAndClusterService)
    {
      _visualizationDataService = visualizationDataService;
      _mergeAndClusterService = mergeAndClusterService;
    }

    public NotifyAndUpdateData GetById(int id)
    {
      throw new NotImplementedException();
    }

    public NotifyAndUpdateData Add(NotifyAndUpdateData data)
    {
      var parsedAndAnalyzedData = _visualizationDataService.ParseAndAnalyze<JavaCodeParser, JavaCodeAnalyzer>();
      var mergedAndClustered = _mergeAndClusterService.MergedAndCluster();

      //TODO: save the result object for access later. Currently just reruns all of the code
      //TODO: save the notifyobject to a data store.

      return data;
    }
  }
}