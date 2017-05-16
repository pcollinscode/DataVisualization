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
    private readonly ICodeAnalyzerFactory _codeAnalyzerFactory;

    public ParsedCodeController(IParsedCodeRepository parsedCodeRepository, ICodeAnalyzerFactory codeAnalyzerFactory)
    {
      _parsedCodeRepository = parsedCodeRepository;
      _codeAnalyzerFactory = codeAnalyzerFactory;
    }
    [Route]
    public async Task<IHttpActionResult> Get()
    {
      var result = await _parsedCodeRepository.Get();

      return Ok(result);
    }
    [Route("{id}")]
    public async Task<IHttpActionResult> Get(string id)
    {
      var analyzer = _codeAnalyzerFactory.CreateCodeAnalyzer<JavaCodeAnalyzer>();
      var result = analyzer.Analyze(id);

      return Ok(result);
    }
    [Route]
    public IHttpActionResult Post(ParsedCode parsedCode)
    {
      return Created("", parsedCode);
    }
    [Route("{id}")]
    public IHttpActionResult Delete(string id)
    {
      return Ok();
    }
  }
}
