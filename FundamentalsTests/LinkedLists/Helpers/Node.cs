namespace FundamentalsTests.LinkedLists.Helpers
{
  internal class Node<T>
  {
    private T data;
    private Node<T> next;

    internal Node(T data, Node<T> next = null)
    {
      this.data = data;
      this.next = next;
    }

    internal T Value
    {
      get
      {
        return data;
      }
      set
      {
        data = value;
      }
    }

    internal Node<T> Next
    {
      get
      {
        return next;
      }
      set
      {
        next = value;
      }
    }
  }
}
