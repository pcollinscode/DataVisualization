namespace DataVisualization.Factories
{
  public interface ICodeParserFactory
  {
    T CreateCodeParser<T>() where T : class, ICodeParser;
  }
}
