using System.Diagnostics;

namespace EmployeeManagementAPI.Performance;

public class PerformanceTest
{
    public static async Task RunAsync()
    {
        var stopwatch = new Stopwatch();

        // Sequential Execution
        stopwatch.Start();

        await Task.Delay(2000);
        await Task.Delay(2000);

        stopwatch.Stop();

        Console.WriteLine(
            $"Sequential Time: {stopwatch.ElapsedMilliseconds} ms"
        );

        stopwatch.Reset();

        // Parallel Execution
        stopwatch.Start();

        await Task.WhenAll(
            Task.Delay(2000),
            Task.Delay(2000)
        );

        stopwatch.Stop();

        Console.WriteLine(
            $"Parallel Time: {stopwatch.ElapsedMilliseconds} ms"
        );
    }
}