# Fundamentals Tests

Based on the idea that whenever you have a question about something fundamental in the C# language or are unsure how something works, the best way to tackle it is to write a test for it, I’ve decided to create this project that contains different tests for simple, yet sometime intriguing, components of the C# language.

The project uses NUnit as external package.

The project is verified using:
[![CircleCI](https://circleci.com/gh/acraileanu/FundamentalsTests/tree/master.svg?style=svg)](https://circleci.com/gh/acraileanu/FundamentalsTests/tree/master)
[![CodeFactor](https://www.codefactor.io/repository/github/acraileanu/fundamentalstests/badge)](https://www.codefactor.io/repository/github/acraileanu/fundamentalstests)


## String.Intern

[MSDN Documentation](https://msdn.microsoft.com/en-us/library/system.string.intern(v=vs.110).aspx)

**Purpose**: tests to explain the reference and equality for strings and the internal string pool


## Strings Are Reference Types

[MSDN Documentation](https://msdn.microsoft.com/en-us/library/system.string(v=vs.110).aspx)

**Purpose**: tests to show that string is not a value type, but a reference type and showing how a string variable behaves when being passed as a parameter

**Note**: one common mistake is considering strings are value types, instead of reference types

This may be due to the fact that when passing a string to a function and "changing the value" of that string inside that function, the outside value is not changed.
However, the reason for this is not that the string is a value type, but rather that the string is immutable so, although the next function may seem as it is changing the state of the object, it is actually returning another instance for it:
```
void ChangeValue(string input)
{
  input = "new value";
}

void Main()
{
  var s = "input value";
  ChangeValue(s);
}
```


## Passing parameters

[MSDN Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters)

**Purpose**: tests to demonstrate the expected behavior of value and reference types being passed as parameters

**Note**: this also covers the structs tests, as another common mistake is to think of them as reference types, instead of value type


## Checked vs. Unchecked

[MSDN Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked-and-unchecked)

**Purpose**: tests to demonstrate the difference between checked and unchecked code


## Stacks implementation with Linked List

[MSDN Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1)

**Purpose**: tests to demonstrate the expected behavior of stack implemented with a linked list


## Queues implementation with Linked List

[MSDN Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)

**Purpose**: tests to demonstrate the expected behavior of queue implemented with a linked list


## Trees

[MSDN Documentation](https://msdn.microsoft.com/en-us/library/ms379570(v=vs.80).aspx)

**Purpose**: tests to demonstrate the expected behavior of binary (search) trees


## Sorts

[Documentation](https://en.wikipedia.org/wiki/Sorting_algorithm)

**Purpose**: tests to different sorting algorithms

Implemented algorithms:
- Selection sort
- Bubble sort
- Insertion sort
- Merge Sort

## Contributing

We welcome community contributions to this project. Please see [CONTRIBUTING.md](./CONTRIBUTING.md) for more details.

By contributing your code, you agree to license your contribution under the terms of the [GNU GENERAL PUBLIC LICENSE](LICENSE).

## License

All files are released with the [GNU GENERAL PUBLIC LICENSE](LICENSE).

## TODO:
- more sorts
  - quick sort
  - heap sort
  - counting sort
  - radix sort
- graphs - https://msdn.microsoft.com/en-us/library/ms379574(v=vs.80).aspx
  - minimum spanning tree
  - shortest path
  - bfs / dfs
- hashset - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?redirectedfrom=MSDN&view=netframework-4.7.2
- balancing trees
  - avl trees
  - golden trees
  - red black trees
  - b-trees
- fibonacci
