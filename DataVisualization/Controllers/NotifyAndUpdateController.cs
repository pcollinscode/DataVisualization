using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataVisualization.Models;
using DataVisualization.Services;

namespace DataVisualization.Controllers
{
  [RoutePrefix("notifyupdate")]
  public class NotifyAndUpdateController : ApiController
  {
    private readonly INotifyAndUpdateService _notifyAndUpdateService;

    public NotifyAndUpdateController(INotifyAndUpdateService notifyAndUpdateService)
    {
      _notifyAndUpdateService = notifyAndUpdateService;
    }

    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = _notifyAndUpdateService.Get();

      return Ok(result);
    }

    [Route("{id}", Name = "GetNotifyAndUpdateById")]
    public async Task<IHttpActionResult> Get(int id)
    {
      try
      {
        var result = _notifyAndUpdateService.Get(id);

        return Ok(result);
      }
      catch (ArgumentException)
      {
        return NotFound();
      }
    }

    [Route]
    public IHttpActionResult Post(NotifyAndUpdateData data)
    {
      var result = _notifyAndUpdateService.Add(data);

      var createdUri = Url.Link("GetNotifyAndUpdateById", new { id = result.id });

      return Created(new Uri(createdUri), result);
    }
    //[Route("{id}")]
    public IHttpActionResult Delete(int id)
    {
      return Ok();
    }
  }
}
