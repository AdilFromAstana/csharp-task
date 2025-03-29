public static class AsyncHelper
{
    private static long Factorial(int n) => (n == 1) ? 1 : n * Factorial(n - 1);
    public static async Task PrintHelloAsync()
    {
        await Task.Delay(3000);
        Console.WriteLine("Hello World!");
    }

    public static async Task CalculateFactorialAsync()
    {
        var tasks = Enumerable.Range(1, 10).Select(n => Task.Run(() =>
        {
            long factorial = Factorial(n);
            Console.WriteLine($"Factorial {n} = {factorial}");
            return factorial;
        }));

        await Task.WhenAll(tasks);
    }
}