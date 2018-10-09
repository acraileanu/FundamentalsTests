using System;
using System.Runtime.Serialization;

namespace FundamentalsTests.LinkedLists.Queues.Helpers
{
  [Serializable]
  public class EmptyQueueException : Exception
  {
    private static string GetMessage(string message = null)
    {
      return $"Queue is empty{(message != null ? " " + message : string.Empty)}!";
    }

    public EmptyQueueException() : base(GetMessage()) {}

    public EmptyQueueException(string message) : base(GetMessage(message)) {}

    public EmptyQueueException(string message, Exception innerException) : base(GetMessage(message), innerException) {}

    protected EmptyQueueException(SerializationInfo info, StreamingContext context) : base(info, context) {}
  }
}
