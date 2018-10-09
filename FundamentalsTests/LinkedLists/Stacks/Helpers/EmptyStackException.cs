using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Stacks.Helpers
{
  [Serializable]
  public class EmptyStackException : Exception
  {
    private static string GetMessage(string message = null)
    {
      return $"Stack is empty{(message != null ? " " + message : string.Empty)}!";
    }

    public EmptyStackException() : base(GetMessage()) { }

    public EmptyStackException(string message) : base(GetMessage(message)) {}

    public EmptyStackException(string message, Exception innerException) : base(GetMessage(message), innerException) {}

    protected EmptyStackException(SerializationInfo info, StreamingContext context) : base(info, context) {}
  }
}
