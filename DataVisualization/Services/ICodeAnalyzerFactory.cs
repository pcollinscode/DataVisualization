using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVisualization.Models.Enumerators;

namespace DataVisualization.Services
{
  public interface ICodeAnalyzerFactory
  {
    ICodeAnalyzer GetAnalyzer(CodeAnalyzerEnum codeAnalyzer);
  }
}
