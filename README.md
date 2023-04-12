# Introduction
FluentRegularExpression is a powerful library for building complex regular expressions in C#. With this library, you can easily create regular expressions that match a wide range of patterns.

The library provides a FluentRegexBuilder class that lets you build regular expressions by chaining together methods that represent different elements of the pattern. These methods include things like Any(), Word(), OneOrMore(), and many more.

```c#
    builder.Any().ZeroOrMore();
```

Using FluentRegularExpression, you can create regular expressions that match specific patterns, validate input strings, and extract data from strings based on patterns. Whether you're working on a small project or a large enterprise application, FluentRegularExpression makes it easy to create powerful regular expressions in C#.

# Regular Expressions - Quick Reference

You can check Microsoft's Quick Reference here : https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference


# Installation

TBD


# How to use

Check if the string has characters:
```c#
    var builder = new FluentRegexBuilder();

    builder.Expressions
        .Any().ZeroOrMore();

    var pattern = builder.Pattern;

    // pattern will have the following value: .*
```

Check if the string has exact 10 digits:
```c#
    var builder = new FluentRegexBuilder();

    builder.Expressions
        .StartOfStringOrLine()
        .Digit()
        .Exactly(10)
        .EndOfString();

    var pattern = builder.Pattern;

    // pattern will have the following value: ^\d{10}$
```

Verify if there is a match:
```c#
    var builder = new FluentRegexBuilder();

    builder.Expressions
        .Any().ZeroOrMore();

    // builder.Pattern will have the following value: .*

    // Call IsMatch just like you're calling Regex's IsMatch method
    builder.IsMatch("teststring"); // returns true
```

Get matches:
```c#
    var builder = new FluentRegexBuilder();

    builder.Expressions
        .Any().ZeroOrMore();

    // builder.Pattern will have the following value: .*

    // Call Matches just like you're calling Regex's Matches method
    var matches = builder.Matches("teststring"); 
```

# Dependencies

- xUnit
- AltCover
- dotnet-reportgenerator-globaltool - https://www.nuget.org/packages/dotnet-reportgenerator-globaltool
