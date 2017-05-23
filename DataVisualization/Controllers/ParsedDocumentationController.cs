using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Factories;
using DataVisualization.Models;
using DataVisualization.Repository;

namespace DataVisualization.Controllers
{
  [RoutePrefix("parseddocument")]
  public class ParsedDocumentationController : ApiController
  {
    private readonly IParsedDocumentationRepository _parsedDocumentationRepository;

    public ParsedDocumentationController(IParsedDocumentationRepository parsedDocumentationRepository)
    {
      _parsedDocumentationRepository = parsedDocumentationRepository;
    }

    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = _parsedDocumentationRepository.Get();

      return Ok(result);
    }
    //[Route("{id}")]
    public async Task<IHttpActionResult> Get(int id)
    {
      return Ok();
    }
    //[Route("{id}")]
    public IHttpActionResult Delete(int id)
    {
      return Ok();
    }
  }
}
