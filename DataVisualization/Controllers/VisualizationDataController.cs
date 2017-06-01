using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Services;

namespace DataVisualization.Controllers
{
  [RoutePrefix("visualizationdata")]
  public class VisualizationDataController : ApiController
  {
    private readonly IVisualizationDataService _visualizationDataService;

    public VisualizationDataController(IVisualizationDataService visualizationDataService)
    {
      _visualizationDataService = visualizationDataService;
    }

    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = _visualizationDataService.Get();

      return Ok(result);
    }
    [Route("{id}")]
    public async Task<IHttpActionResult> GetById(int id)
    {
      var result = _visualizationDataService.GetById(id);

      return Ok(result);
    }
  }
}
