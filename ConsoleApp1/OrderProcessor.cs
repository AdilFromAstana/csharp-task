namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;

public static class OrderProcessor
{
    public static void ProcessOrders()
    {
        var orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                Products =
                [
                    new Product
                    {
                        Id = 1, Name = "Кофе"
                    },
                    new Product
                    {
                        Id = 2, Name = "Чай"
                    }
                ]
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
            .GroupBy(o => o.Name)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach (var product in productCounts)
        {
            Console.WriteLine($"{product.Key} : {product.Value}");
        }

        var mostPopularProduct = productCounts.OrderByDescending(p => p.Value).First().Key;
        Console.WriteLine($"Самый популярный товар: {mostPopularProduct}");
    }
}