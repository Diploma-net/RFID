using Prometheus;

namespace RFLOT.Gateway.Metrics;

public class MetricReporter(ILogger<MetricReporter> logger)
{
    private readonly ILogger<MetricReporter> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private readonly Counter _requestCounter =
        Prometheus.Metrics.CreateCounter("total_requests", "The total number of requests serviced by this API.");

    private readonly Histogram _responseTimeHistogram = Prometheus.Metrics.CreateHistogram("request_duration_seconds",
        "The duration in seconds between the response to a request.", new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
            LabelNames = new[] { "status_code", "method" }
        });

    public void RegisterRequest()
    {
        _requestCounter.Inc();
    }

    public void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed)
    {
        _responseTimeHistogram.Labels(statusCode.ToString(), method).Observe(elapsed.TotalSeconds);
    }
}