# FundamentalsTests

Based on the idea that whenever you have a question about something fundamental in the C# language or are unsure how something works, the best way to tackle it is to write a test for it, I’ve decided to create this project that contains different tests for simple, yet sometime intriguing, components of the C# language.

The project uses NUnit as external package.


## String.Intern

MSDN Documentation: https://msdn.microsoft.com/en-us/library/system.string.intern(v=vs.110).aspx

Purpose: tests to explain the reference and equality for strings and the internal string pool.

## Strings Are Reference Types

MSDN Documentation: https://msdn.microsoft.com/en-us/library/system.string(v=vs.110).aspx

One common mistake is considering strings are value types, instead of reference types.

This may be due to the fact that when passing a string to a function and "changing the value" of that string inside that function, the outside value is not changed.
However, the reason for this is not that the string is a value type, but rather that the string is immutable so, although the next function may seem as it is changing the state of the object, it is actually returning another instance for it:
void ChangeValue(string input)
{
	input = "new value";
}

var s = "input value";
ChangeValue(s);