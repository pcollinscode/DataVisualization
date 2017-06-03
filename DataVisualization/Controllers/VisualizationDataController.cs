using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Factories.CodeAnalyzer;
using DataVisualization.Factories.CodeParser;
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

    [Route("{id}")]
    public async Task<IHttpActionResult> GetById(int id)
    {
      //TODO: replace this with a stored resource
      var result = _visualizationDataService.ParseAndAnalyze<JavaCodeParser, JavaCodeAnalyzer>();

      return Ok(result);
    }
  }
}
