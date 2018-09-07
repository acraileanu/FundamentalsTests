namespace FundamentalsTests.Trees.Helpers
{
  internal class Node<T>
  {
    public T Value { get; protected set; }

    public NodeList<T> LinkedNodes { get; protected set; }

    internal Node() {}
    internal Node(T value, NodeList<T> linkedNodes = null)
    {
      Value = value;
      LinkedNodes = linkedNodes;
    }
  }
}
