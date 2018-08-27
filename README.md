# Fundamentals Tests

Based on the idea that whenever you have a question about something fundamental in the C# language or are unsure how something works, the best way to tackle it is to write a test for it, I’ve decided to create this project that contains different tests for simple, yet sometime intriguing, components of the C# language.

The project uses NUnit as external package.


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

[MSDN Documentation](https://msdn.microsoft.com/en-us/library/0f66670z(v=vs.71).aspx)

**Purpose**: tests to demonstrate the expected behavior of value and reference types being passed as parameters

**Note**: this also covers the structs tests, as another common mistake is to think of them as reference types, instead of value type


## Checked vs. Unchecked

[MSDN Documentation](https://msdn.microsoft.com/en-us/library/74b4xzyw(v=vs.71).aspx)

**Purpose**: tests to demonstrate the difference between checked and unchecked code


## Queues implementation with Linked List

[MSDN Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)

**Purpose**: tests to demonstrate the expected behavior of queue implemented with a linked list
