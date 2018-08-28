using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Stacks.Helpers
{
  [Serializable]
  public class EmptyStackException : Exception
  {
    private static string getMessage(string message = null){
      return $"Stack is empty{(message != null ? " " + message : "")}!";
    }

    public EmptyStackException() : base(getMessage()) {}

    public EmptyStackException(string message) : base(getMessage(message)) {}

    public EmptyStackException(string message, Exception innerException) : base(getMessage(message), innerException)
    {
    }

    protected EmptyStackException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
