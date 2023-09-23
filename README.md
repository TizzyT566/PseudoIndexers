# PseudoIndexers
Enables indexer-like properties.

Similar to how VB.Net properties can have index parameters.

This also enables having multiple indexers in a class distinguished by name.

## Example

```csharp
using static System.PseudoIndexers;

class Example
{
    // Indexer with get and set
    public Indexer<int, string> Strings { get; }
    private string StringsGetter(int index)
    {
        // Getter code here
    }
    private void StringsSetter(int index, string? str)
    {
        // Setter code here
    }

    // Indexer with only get
    public ReadOnlyIndexer<int, long> Longs { get; }
    private long LongGetter(int index)
    {
        // Getter code here
    }

    // Indexer with only set
    public WriteOnlyIndexer<int, double> Doubles { get; }
    private void DoubleSetter(int index, double dbl)
    {
        // Setter code here
    }

    public Example()
    {
        Strings = new(StringsGetter, StringsSetter);
        Longs = new(LongGetter);
        Doubles = new(DoubleSetter);
    }
}

// Or the lambda way

class Example
{
    // Indexer with get and set
    public Indexer<int, string> Strings { get; } = new(
        index =>
        {
            // Getter code here
        },
        (index, str) =>
        {
            // Setter code here
        });

    // Indexer with only get
    public ReadOnlyIndexer<int, long> Longs { get; } = new(
        Index =>
        {
            // Getter code here
        });

    // Indexer with only set
    public WriteOnlyIndexer<int, double> Doubles { get; } = new(
        (index, dbl) =>
        {
            // Setter code here
        });
}
```

Usage:

```csharp
Example example = new();

// Indexer with get and set
Console.WriteLine(example.Strings[0]);
example.Strings[1] = "Hello World";

// Indexer with only get
Console.WriteLine(example.Strings[2]);

// Indexer with only set
example.Doubles[3] = 712247.7357;
```