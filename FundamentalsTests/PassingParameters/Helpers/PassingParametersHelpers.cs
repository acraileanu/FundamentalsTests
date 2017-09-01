using System;

namespace FundamentalsTests.PassingParameters.Helpers
{
	internal static class PassingParametersHelpers
	{
		internal static void ChangeInt(int input)
		{
			input = GetIncrementedIntOrMinValue(input);
			Console.WriteLine("Value inside method is {0}", input);
		}

		internal static void ChangeIntWithReference(ref int input)
		{
			input = GetIncrementedIntOrMinValue(input);
			Console.WriteLine("Value inside method is {0}", input);
		}

		private static int GetIncrementedIntOrMinValue(int input)
		{
			return input == int.MaxValue ?
				int.MinValue :
				input + 1;
		}

		internal static void ChangePropertyValue(ITypeWithIntProperty input)
		{
			input.Property = GetIncrementedIntOrMinValue(input.Property);
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}

		internal static void ReinitializeObject(ObjectWithIntProperty input)
		{
			input = new ObjectWithIntProperty { Property = GetIncrementedIntOrMinValue(input.Property) };
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}

		internal static void ReinitializeObjectWithReference(ref ObjectWithIntProperty input)
		{
			input = new ObjectWithIntProperty { Property = GetIncrementedIntOrMinValue(input.Property) };
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}

		internal static void ChangePropertyValueWithReference(ref StructWithIntProperty input)
		{
			input.Property = GetIncrementedIntOrMinValue(input.Property);
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}

		internal static void ReinitializeStruct(StructWithIntProperty input)
		{
			input = new StructWithIntProperty { Property = GetIncrementedIntOrMinValue(input.Property) };
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}

		internal static void ReinitializeStructWithReference(ref StructWithIntProperty input)
		{
			input = new StructWithIntProperty { Property = GetIncrementedIntOrMinValue(input.Property) };
			Console.WriteLine("Property value inside method is {0}", input.Property);
		}
	}
}