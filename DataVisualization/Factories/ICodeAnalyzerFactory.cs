namespace DataVisualization.Factories
{
  public interface ICodeAnalyzerFactory
  {
    T CreateCodeAnalyzer<T>() where T : class, ICodeAnalyzer;
  }
}
