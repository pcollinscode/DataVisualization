using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public interface IParsedDocumentationRepository
  {
    Task<ParsedDocumentation> Get();
    Task<ParsedDocumentation> Get(int id);
    Task Create(ParsedDocumentation entity);
    Task Delete(int id);
    Task<ParsedDocumentation> Update(ParsedDocumentation entity);
  }
}
