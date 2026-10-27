using LINQ.DataSources;
using LINQ.Models;

namespace Linq01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q1:");
            var seafood = Source.ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);
            Console.WriteLine();

            Console.WriteLine("Q2:");
            var names = Source.ProductList.Select(p => p.ProductName);
            foreach (var name in names)
                Console.WriteLine(name);
            Console.WriteLine();

            Console.WriteLine("Q3:");
            var sortedByPrice = Source.ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in sortedByPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            Console.WriteLine();

            Console.WriteLine("Q4:");
            var result4 = Source.ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in result4)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            Console.WriteLine();

            // the category in the data is called "Spices & Condiments"
            Console.WriteLine("Q5:");
            var condiments = Source.ProductList.Where(p => p.Category == "Spices & Condiments" && p.UnitsInStock > 0);
            foreach (var p in condiments)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice} - InStock: {p.UnitsInStock}");
            Console.WriteLine();

            Console.WriteLine("Q6:");
            var result6 = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in result6)
                Console.WriteLine($"{item.Name} - {item.Price} - {item.StockStatus}");
            Console.WriteLine();

            Console.WriteLine("Q7:");
            var numbered = Source.ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");
            Console.WriteLine(string.Join(", ", numbered));
            Console.WriteLine();

            Console.WriteLine("Q8:");
            var result8 = Source.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var p in result8)
                Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");
            Console.WriteLine();

            Console.WriteLine("Q9:");
            var beverages = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
            Console.WriteLine();

            // Q10 must be query syntax
            Console.WriteLine("Q10:");
            var orders =
                from c in Source.CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };
            foreach (var o in orders)
                Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");
            Console.WriteLine();

            Console.WriteLine("Q11:");
            var result11 = Source.ProductList.Select((p, index) => new { Num = index + 1, p.ProductName });
            foreach (var item in result11)
                Console.WriteLine(item.Num + ". " + item.ProductName);
            Console.WriteLine();

            Console.WriteLine("Q12:");
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedWords)
                Console.WriteLine(w);
            Console.WriteLine();

            Console.WriteLine("Q13:");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsResult = digits.Where(d => d[1] == 'i').Reverse();
            foreach (var d in digitsResult)
                Console.WriteLine(d);
        }
    }
}
