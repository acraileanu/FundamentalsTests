using System;

namespace FundamentalsTests.PassingParameters.Helpers
{
  public struct StructWithIntProperty : ITypeWithIntProperty, IEquatable<StructWithIntProperty>
  {
    public int IntegerProperty { get; set; }

    public override bool Equals(object obj)
    {
      if (obj.GetType() != typeof(StructWithIntProperty))
      {
        return false;
      }

      return this.Equals((StructWithIntProperty)obj);
    }

    public bool Equals(StructWithIntProperty obj)
    {
      return this.IntegerProperty == ((StructWithIntProperty)obj).IntegerProperty;
    }

    public static bool operator ==(StructWithIntProperty toCompare, StructWithIntProperty compareWith)
    {
      return toCompare.Equals(compareWith);
    }

    public static bool operator !=(StructWithIntProperty toCompare, StructWithIntProperty compareWith)
    {
      return !toCompare.Equals(compareWith);
    }

    public override int GetHashCode(){
      return this.IntegerProperty.GetHashCode();
    }
  }
}
