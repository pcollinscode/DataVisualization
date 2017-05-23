using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Factories;
using DataVisualization.Models;

namespace DataVisualization.Controllers
{
  [RoutePrefix("parseddocument")]
  public class ParsedDocumentationController : ApiController
  {
    [Route]
    public async Task<IHttpActionResult> Get()
    {
      return Ok();
    }
    [Route("{id}")]
    public async Task<IHttpActionResult> Get(int id)
    {
      return Ok();
    }
    [Route("{id}")]
    public IHttpActionResult Delete(int id)
    {
      return Ok();
    }
  }
}
