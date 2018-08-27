using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Helpers.Queues
{
  [Serializable]
  internal class EmptyQueueException : Exception
  {
    private static string getMessage(string message = null){
      return $"Queue is empty{(message != null ? " " + message : "")}!";
    }

    internal EmptyQueueException() : base(getMessage()) {}

    internal EmptyQueueException(string message) : base(getMessage(message)) {}

    internal EmptyQueueException(string message, Exception innerException) : base(getMessage(message), innerException)
    {
    }

    internal EmptyQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
