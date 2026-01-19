namespace NBomber.Sinks.Otel;

/// <summary>
/// Configuration settings for the OpenTelemetry (Otel) Sink in NBomber.
/// </summary>
public sealed record OtelSinkConfig
{
    /// <summary>
    /// The OTLP endpoint where the Otel Sink exports metrics, to be scraped by Prometheus
    /// or any other metrics backend using an Otel Collector.
    /// </summary>
    public string OtlpExportEndpoint { get; set; } = "http://localhost:9464/metrics";

    /// <summary>
    /// All custom tags that will be added to each metric exported by the Otel Sink.
    /// </summary>
    public CustomTag[] CustomTags { get; set; } = [];

    /// <summary>
    /// The default configuration for the Otel Sink. Used for figure out if the user provided custom config or not.
    /// </summary>
    public static OtelSinkConfig Default { get; } = new();
}
