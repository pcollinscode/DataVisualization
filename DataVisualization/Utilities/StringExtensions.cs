namespace DataVisualization.Utilities
{
  public static class StringExtensions
  {
    public static string FormatString(this string item, params object[] values)
    {
      return string.Format(item, values);
    }
  }
}