namespace FundamentalsTests.LinkedLists.Helpers
{
  internal class Node<TValue>
  {
    internal TValue Value { get; set; }

    internal Node<TValue> Next { get; set; }

    internal Node(TValue value, Node<TValue> next = null)
    {
      Next = next;
      Value = value;
    }
  }
}
