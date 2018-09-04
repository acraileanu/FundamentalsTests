using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Queues.Helpers
{
  [Serializable]
  public class EmptyQueueException : Exception
  {
    private static string getMessage(string message = null)
    {
      return $"Queue is empty{(message != null ? " " + message : "")}!";
    }

    public EmptyQueueException() : base(getMessage()) {}

    public EmptyQueueException(string message) : base(getMessage(message)) {}

    public EmptyQueueException(string message, Exception innerException) : base(getMessage(message), innerException) {}

    protected EmptyQueueException(SerializationInfo info, StreamingContext context) : base(info, context) {}
  }
}
