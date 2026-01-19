namespace NBomber.Sinks.Otel;

/// <summary>
/// A custom tag consisting of a key-value pair to be added to each metric exported by the Otel Sink.
/// </summary>
public sealed record CustomTag
{
    public string Key { get; set; } = null!;
    public object? Value { get; set; }
}
