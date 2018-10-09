namespace FundamentalsTests.Trees.Helpers
{
  public class Node<T>
  {
    public T Value { get; protected set; }

    public NodeListCollection<T> LinkedNodes { get; }

    public Node()
    {
      LinkedNodes = new NodeListCollection<T>();
    }

    public Node(T value, NodeListCollection<T> linkedNodes = null)
    {
      Value = value;
      LinkedNodes = linkedNodes;
    }
  }
}
