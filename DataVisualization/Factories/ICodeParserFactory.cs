using DataVisualization.Models.Enumerators;

namespace DataVisualization.Factories
{
  public interface ICodeParserFactory
  {
    ICodeParser GetCodeParser(CodeParsersEnum codeParser);
  }
}
