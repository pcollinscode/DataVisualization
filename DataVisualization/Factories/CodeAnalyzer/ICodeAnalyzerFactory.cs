namespace DataVisualization.Factories.CodeAnalyzer
{
  public interface ICodeAnalyzerFactory
  {
    T CreateCodeAnalyzer<T>() where T : class, ICodeAnalyzer;
  }
}
