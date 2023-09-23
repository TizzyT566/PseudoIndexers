using PseudoIndexers;

Example example = new();

// Indexer with get and set
Console.WriteLine(example.Strings[0]);
example.Strings[1] = "Hello World";

// Indexer with only get
Console.WriteLine(example.Strings[2]);

// Indexer with only set
example.Doubles[3] = 712247.7357;

class Example
{
    // Indexer with get and set
    public Indexer<int, string> Strings { get; }
    private string StringsGetter(int index)
    {
        return index.ToString();
    }
    private void StringsSetter(int index, string? str)
    {
        Console.WriteLine($"{index}:{str}");
    }

    // Indexer with only get
    public ReadOnlyIndexer<int, long> Longs { get; }
    private long LongsGetter(int index)
    {
        return index;
    }

    // Indexer with only set
    public WriteOnlyIndexer<int, double> Doubles { get; }
    private void DoublesSetter(int index, double dbl)
    {
        Console.WriteLine($"{index}:{dbl}");
    }

    public Example()
    {
        Strings = new(StringsGetter, StringsSetter);
        Longs = new(LongsGetter);
        Doubles = new(DoublesSetter);
    }
}