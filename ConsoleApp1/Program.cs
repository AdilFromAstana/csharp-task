using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1, 
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1, Name = "Кофе"
                    }, 
                    new Product
                    {
                        Id = 2, Name = "Чай"
                    }
                }
            },
            new Order
            {
                OrderId = 2,
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1, Name = "Кофе"
                    }, 
                    new Product
                    {
                        Id = 3, Name = "Сок"
                    }
                }
            },
            new Order
            {
                OrderId = 3,
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 2, Name = "Чай"
                    }, 
                    new Product
                    {
                        Id = 3, Name = "Сок"
                    }, 
                    new Product
                    {
                        Id = 1, Name = "Кофе"
                    }
                }
            },
            new Order 
            { 
                OrderId = 4, 
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Кофе" }
                } 
            },
            new Order
            {
                OrderId = 5, 
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 2, Name = "Чай"
                    }, 
                    new Product
                    {
                        Id = 1, Name = "Кофе"
                    }
                }
            }
        };
    
        var productCounts = orders
            .SelectMany(o => o.Products)
            .GroupBy((o)=>o.Name)
            .ToDictionary(g=>g.Key, g=>g.Count());
    
        foreach (var product in productCounts)
        {
            Console.WriteLine($"Товар \"{product.Key}\" куплен {product.Value} раз");
        }
        
        var mostPopularProduct = productCounts.OrderByDescending(p => p.Value).First().Key;
        Console.WriteLine($"Самый популярный товар: {mostPopularProduct}");
        Console.WriteLine("-------------------------------------");

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
            Console.WriteLine($"UserId: {transaction.UserId}, сумма транзакций: {transaction.TotalAmount}");
        }
    }

}