using System.Threading.Tasks;
using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public interface IParsedCodeRepository
  {
    Task<ParsedCode> Get();
    Task<ParsedCode> Get(int id);
    Task Create(ParsedCode entity);
    Task Delete(int id);
    Task<ParsedCode> Update(ParsedCode entity);
  }
}
