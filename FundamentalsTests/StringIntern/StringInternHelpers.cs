using System.Text;

namespace FundamentalsTests.StringIntern
{
	internal class StringInternHelpers
	{
		internal static string GetLiteral()
		{
			return "x";
		}

		internal static string GetNonLiteral()
		{
			return new StringBuilder("x").ToString();
		}
	}
}