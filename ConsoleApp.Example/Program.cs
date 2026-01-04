using Railway.Functional;

namespace ConsoleApp.Example;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SUCCESS FLOW ===");

        Result<int>.Ok(100)
            .OnSuccess(v => Console.WriteLine($"Initial value: {v}"))
            .OnSuccess(v => Console.WriteLine($"Processed value: {v}"))
            .OnFail(err => Console.WriteLine($"Error: {err}"));

        Console.WriteLine();
        Console.WriteLine("=== FAILURE FLOW ===");

        Result<int>.Fail("Something went wrong")
            .OnSuccess(v => Console.WriteLine($"Value: {v}"))
            .OnFail(err => Console.WriteLine($"Error: {err}"));

        Console.ReadLine();
    }
}
