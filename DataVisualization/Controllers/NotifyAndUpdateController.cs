using System;
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

    [Route("{id}", Name = "GetNotifyAndUpdateById")]
    public IHttpActionResult GetById(int id)
    {
      var result = _notifyAndUpdateService.GetById(id);

      return Ok(result);
    }
    [Route]
    public IHttpActionResult Post(NotifyAndUpdateData data)
    {
      var result = _notifyAndUpdateService.Add(data);

      var createdUri = Url.Link("GetNotifyAndUpdateById", new { id = result.id });

      return Created(new Uri(createdUri), result);
    }
  }
}
