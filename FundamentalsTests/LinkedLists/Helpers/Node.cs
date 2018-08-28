namespace FundamentalsTests.LinkedLists.Helpers
{
  internal class Node<T>
  {
    internal T Value { get; set; }
    internal Node<T> Next { get; set; }

    internal Node(T value, Node<T> next = null)
    {
      Value = value;
      Next = next;
    }
  }
}
