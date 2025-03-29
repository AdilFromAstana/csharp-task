using ConsoleApp1;

public static class TransactionProcessor
{
    public static void ProcessTransaction()
    {
        var transactions = new List<Transaction>
        {
            new Transaction()
            {
                UserId = 1,
                Amount = 83000,
            },
            new Transaction()
            {
                UserId = 1,
                Amount = 123000,
            },
            new Transaction()
            {
                UserId = 1,
                Amount = 320320,
            },
            new Transaction()
            {
                UserId = 2,
                Amount = 313200,
            },
            new Transaction()
            {
                UserId = 2,
                Amount = 93000,
            },
            new Transaction()
            {
                UserId = 2,
                Amount = 435000,
            },
            new Transaction()
            {
                UserId = 2,
                Amount = -332000,
            },
            new Transaction()
            {
                UserId = 3,
                Amount = -332000,
            },
            new Transaction()
            {
                UserId = 5,
                Amount = 3322100,
            },
            new Transaction()
            {
                UserId = 5,
                Amount = -2441100,
            },
            new Transaction()
            {
                UserId = 4,
                Amount = 332000,
            },
            new Transaction()
            {
                UserId = 3,
                Amount = 100000,
            }
        };

        var top3Transactions = transactions
        .GroupBy(t => t.UserId)
        .Select(t => new { UserId = t.Key, TotalAmount = t.Sum(t => t.Amount) })
        .OrderByDescending(t => t.TotalAmount)
        .Take(3);

        foreach (var transaction in top3Transactions)
        {
            Console.WriteLine($"UserId: {transaction.UserId}, сумма: {transaction.TotalAmount}");
        }
    }
}