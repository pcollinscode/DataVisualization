using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Repository;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Controllers
{
  [RoutePrefix("visualizationdata")]
  public class VisualizationDataController : ApiController
  {
    private readonly IVisualizationDataRepository _visualizationDataRepository;

    public VisualizationDataController(IVisualizationDataRepository visualizationDataRepository)
    {
      _visualizationDataRepository = visualizationDataRepository;
    }

    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = _visualizationDataRepository.Get();

      return Ok(result);
    }
  }
}
