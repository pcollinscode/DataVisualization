using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVisualization.Models;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Repository
{
  public interface IVisualizationDataRepository
  {
    ParsedData GetParsedCodeData();
  }
}
