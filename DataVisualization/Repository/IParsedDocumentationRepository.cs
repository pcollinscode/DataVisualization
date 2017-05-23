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
    List<ParsedDocumentation> Get();
    ParsedDocumentation Get(int id);
    ParsedDocumentation Create(ParsedDocumentation entity);
    void Delete(int id);
    ParsedDocumentation Update(ParsedDocumentation entity);
  }
}
