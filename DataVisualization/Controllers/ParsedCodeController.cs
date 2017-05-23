using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using DataVisualization.Factories;
using DataVisualization.Models;
using DataVisualization.Repository;

namespace DataVisualization.Controllers
{
  [RoutePrefix("parsedcode")]
  public class ParsedCodeController : ApiController
  {
    private readonly IParsedCodeRepository _parsedCodeRepository;

    public ParsedCodeController(IParsedCodeRepository parsedCodeRepository)
    {
      _parsedCodeRepository = parsedCodeRepository;
    }
    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = _parsedCodeRepository.Get();

      return Ok(result);
    }
    //[Route("{id}")]
    public async Task<IHttpActionResult> Get(int id)
    {
      return Ok();
    }
  }
}
