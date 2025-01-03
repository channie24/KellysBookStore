using KellysBookStore.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace KellysBookStore.Service
{
    public class Store
    {
        private List<Book> books = new List<Book>();
        private List<MonthlySales> sales = new List<MonthlySales>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added successfully.");
        }

        public void ListBooks()
        {
            Console.WriteLine("\nBook List:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, ${book.Price} ({book.PublishedYear})");
            }
        }

        public void SearchBooks(string keyword)
        {
            var results = books.Where(b => b.Title.Contains(keyword) ||
                                           b.Author.Contains(keyword)).ToList();

            Console.WriteLine("\nSearch Results:");
            foreach (var book in results)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, ${book.Price} ({book.PublishedYear})");
            }
        }

        public void createBooks()
        {
            var randomBooks = new List<Book>
            {
                new Book("my cute cate channie", "kelly", 42, 2021),
                new Book("her eyes are green", "Jane Smith", 35, 2020),
                new Book("she loves play with me", "John Doe", 50, 2022),
                new Book("and love paper bag", "Jon Skeet", 45, 2019),
                new Book("i am happy because with her", "Eric Freeman", 55, 2018),
                new Book("my cute cate kiri", "kelly", 20, 2024),
                new Book("his eyes are green", "Jane Smith", 34, 2005),
                new Book("he loves play with me", "John Doe", 50, 2010),
                new Book("and love to eat", "Jon Skeet", 22, 2030),
                new Book("i am happy because with him", "Eric Freeman", 101, 2002)
            };
            foreach (Book book in randomBooks)
            {
                books.Add(book);
            }
        }

        public void GenerateSalesData()
        {
            Random random = new Random();
            foreach (var book in books)
            {
                for (int month = 1; month <= 12; month++)
                {
                    sales.Add(new MonthlySales(book.Title, month, random.Next(10, 100)));
                }
            }
            Console.WriteLine("Random sales data generated.");
        }

        public void AnalyzeSalesData()
        {
            // Total revenue for each book
            var totalRevenue = sales.GroupBy(s => s.BookTitle)
                                    .Select(g => new
                                    {
                                        Title = g.Key,
                                        TotalRevenue = g.Sum(s => s.QuantitySold * books.First(b => b.Title == g.Key).Price)
                                    });

            Console.WriteLine("\nTotal Revenue:");
            foreach (var revenue in totalRevenue)
            {
                Console.WriteLine($"{revenue.Title}: ${revenue.TotalRevenue}");
            }

            // Best-selling book
            var bestSeller = sales.GroupBy(s => s.BookTitle)
                                  .OrderByDescending(g => g.Sum(s => s.QuantitySold))
                                  .First();

            Console.WriteLine($"\nBest-Selling Book: {bestSeller.Key}");

            // Month with highest sales
            var highestSalesMonth = sales.GroupBy(s => s.Month)
                                         .OrderByDescending(g => g.Sum(s => s.QuantitySold))
                                         .First();

            Console.WriteLine($"Month with Highest Sales: {highestSalesMonth.Key}");
        }

        public void ExportData(string booksFile, string salesFile)
        {
            try
            {
                // Create Data directory if it doesn't exist
                string directory = Path.GetDirectoryName("C:BookStore");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write books and sales data to JSON files
                File.WriteAllText(booksFile, JsonConvert.SerializeObject(books, Formatting.Indented));
                File.WriteAllText(salesFile, JsonConvert.SerializeObject(sales, Formatting.Indented));

                Console.WriteLine($"Books data exported to: {Path.GetFullPath(booksFile)}");
                Console.WriteLine($"Sales data exported to: {Path.GetFullPath(salesFile)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting data: {ex.Message}");
            }
        }

        public void ImportData(string booksFile, string salesFile)
        {
            try
            {
                // Books 파일 읽기 및 덮어쓰기
                if (File.Exists(booksFile))
                {
                    books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(booksFile)) ?? new List<Book>();
                    Console.WriteLine($"Books data imported successfully from: {Path.GetFullPath(booksFile)}");
                }
                else
                {
                    Console.WriteLine($"Books file '{booksFile}' not found.");
                }

                // Sales 파일 읽기 및 덮어쓰기
                if (File.Exists(salesFile))
                {
                    sales = JsonConvert.DeserializeObject<List<MonthlySales>>(File.ReadAllText(salesFile)) ?? new List<MonthlySales>();
                    Console.WriteLine($"Sales data imported successfully from: {Path.GetFullPath(salesFile)}");
                }
                else
                {
                    Console.WriteLine($"Sales file '{salesFile}' not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing data: {ex.Message}");
            }
        }
    }
}
