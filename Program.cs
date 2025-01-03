using KellysBookStore.Model;
using KellysBookStore.Service;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellysBookStore
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Store bookStore= new Store();
            GoogleBooksAPI gooleApi = new GoogleBooksAPI();

            while (true)
            {
                Console.WriteLine("\nKellysBookStore");
                Console.WriteLine("0. Create Books");
                Console.WriteLine("1. Search Google Books related C#");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. List Books");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Generate Sales Data");
                Console.WriteLine("6. Analyze Sales Data");
                Console.WriteLine("7. Export Data");
                Console.WriteLine("8. Import Data");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                int choice = int.Parse(Console.ReadLine() ?? "0");
                switch (choice)
                {
                    case 1:
                        await gooleApi.FetchBooks("C# Programming");
                        break;
                    case 2:
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Published Year: ");
                        int year = int.Parse(Console.ReadLine());

                        bookStore.AddBook(new Book(title, author, price, year));
                        break;

                    case 3:
                        bookStore.ListBooks();
                        break;

                    case 4:
                        Console.Write("Search keyword: ");
                        string keyword = Console.ReadLine();
                        bookStore.SearchBooks(keyword);
                        break;

                    case 5:
                        bookStore.GenerateSalesData();
                        break;

                    case 6:
                        bookStore.AnalyzeSalesData();
                        break;

                    case 7:
                        bookStore.ExportData("books.json", "sales.json");
                        break;

                    case 8:
                        bookStore.ImportData("books.json", "sales.json");
                        break;

                    case 9:
                        Console.WriteLine("Exiting...");
                        return;

                    case 0:
                        bookStore.createBooks();
                        Console.WriteLine("Created completly.");
                        break;


                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
