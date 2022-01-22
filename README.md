# PsuedoIndexers
Enables indexer-like properties.

Similar to how VB.Net properties can have index parameters.

## Usage

```csharp
using static System.PsuedoIndexers;

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

// Or the shorter way

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

        });
}
```