using System.Text;

namespace FundamentalsTests.StringIntern
{
  public static class LiteralHelpers
  {
    public static string GetLiteral()
    {
      return "x";
    }

    public static string GetNonLiteral()
    {
      return new StringBuilder("x").ToString();
    }
  }
}
