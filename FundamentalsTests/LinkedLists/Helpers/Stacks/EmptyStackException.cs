using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Helpers.Stacks
{
  [Serializable]
  internal class EmptyStackException : Exception
  {
    private static string getMessage(string message = null){
      return $"Stack is empty{(message != null ? " " + message : "")}!";
    }

    internal EmptyStackException() : base(getMessage()) {}

    internal EmptyStackException(string message) : base(getMessage(message)) {}

    internal EmptyStackException(string message, Exception innerException) : base(getMessage(message), innerException)
    {
    }

    internal EmptyStackException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
