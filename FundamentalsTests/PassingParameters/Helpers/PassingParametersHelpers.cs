using System;

namespace FundamentalsTests.PassingParameters.Helpers
{
  public static class PassingParametersHelpers
  {
    public static void ChangeInt(int input)
    {
      input = GetIncrementedIntOrMinValue(input);
      Console.WriteLine("Value inside method is {0}", input);
    }

    public static void ChangeIntWithReference(ref int input)
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

    public static void ChangePropertyValue(ITypeWithIntProperty input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      input.IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty);
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }

    public static void ReinitializeObject(ObjectWithIntProperty input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      input = new ObjectWithIntProperty { IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty) };
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }

    public static void ReinitializeObjectWithReference(ref ObjectWithIntProperty input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      input = new ObjectWithIntProperty { IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty) };
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }

    public static void ChangePropertyValueWithReference(ref StructWithIntProperty input)
    {
      input.IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty);
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }

    public static void ReinitializeStruct(StructWithIntProperty input)
    {
      input = new StructWithIntProperty { IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty) };
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }

    public static void ReinitializeStructWithReference(ref StructWithIntProperty input)
    {
      input = new StructWithIntProperty { IntegerProperty = GetIncrementedIntOrMinValue(input.IntegerProperty) };
      Console.WriteLine("IntegerProperty value inside method is {0}", input.IntegerProperty);
    }
  }
}
