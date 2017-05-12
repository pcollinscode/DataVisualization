using DataVisualization.Models.Enumerators;

namespace DataVisualization.Services
{
  public interface ICodeParserFactory
  {
    ICodeParser GetCodeParser(CodeParsersEnum codeParser);
  }
}
