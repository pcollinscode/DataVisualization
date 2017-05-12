using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public class ParsedCodeRepository : IParsedCodeRepository
  {
    public ParsedCodeRepository()
    {
      
    }
    public Task<ParsedCode> Get(int id)
    {
      throw new NotImplementedException();
    }

    public Task Create(ParsedCode entity)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ParsedCode> Update(ParsedCode entity)
    {
      throw new NotImplementedException();
    }
  }
}