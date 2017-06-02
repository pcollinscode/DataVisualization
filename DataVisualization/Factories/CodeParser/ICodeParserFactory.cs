namespace DataVisualization.Factories.CodeParser
{
  public interface ICodeParserFactory
  {
    T CreateCodeParser<T>() where T : class, ICodeParser;
  }
}
