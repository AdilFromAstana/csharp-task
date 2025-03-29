public class WebScraper
{
    public static async Task<int> GetWordCountAsync(string url)
    {
        using HttpClient client = new HttpClient();
        string content = await client.GetStringAsync(url);
        return content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
