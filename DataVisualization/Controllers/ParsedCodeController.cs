using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using DataVisualization.Models;

namespace DataVisualization.Controllers
{
  [RoutePrefix("parsedcode")]
  public class ParsedCodeController : ApiController
  {
    public ParsedCodeController()
    {
      
    }
    [Route]
    public IHttpActionResult Get()
    {
      return Ok();
    }
    [Route("{id}")]
    public IHttpActionResult Get(string id)
    {
      return Ok();
    }
    [Route]
    public IHttpActionResult Post(ParsedCode parsedCode)
    {
      return Created("", parsedCode);
    }
  }
}
