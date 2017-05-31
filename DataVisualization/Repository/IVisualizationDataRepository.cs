using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataVisualization.Repository
{
  public interface IVisualizationDataRepository
  {
    JObject Get();
    JObject GetById(int id);
  }
}
