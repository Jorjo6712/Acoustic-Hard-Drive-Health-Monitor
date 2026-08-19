using System.Diagnostics;

namespace hdd_health_monitor.Common.FastEndpoints;

public class PerformancePreProcessor : IGlobalPreProcessor
{
    private const string ActivityKey = "PerformanceStopwatch";
    
    public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
    {
        var stopwatch = Stopwatch.StartNew();
        context.HttpContext.Items[ActivityKey] = stopwatch;
        await Task.CompletedTask;
    }
}