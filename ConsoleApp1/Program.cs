using ConsoleApp1;

public class Program
{
    public static async Task Main(string[] args)
    {
        OrderProcessor.ProcessOrders();

        TransactionProcessor.ProcessTransaction();

        await AsyncHelper.PrintHelloAsync();

        await AsyncHelper.CalculateFactorialAsync();

        string[] urls = { "https://example.com", "https://google.com", "https://microsoft.com" };

        var tasks = urls.Select(WebScraper.GetWordCountAsync);
        var results = await Task.WhenAll(tasks);

        for (int i = 0; i < urls.Length; i++)
        {
            Console.WriteLine($"{urls[i]}: {results[i]} слов");
        }
    }

}