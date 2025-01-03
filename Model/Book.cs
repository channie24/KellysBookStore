using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellysBookStore.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int PublishedYear { get; set; }


        public Book(string title, string author, decimal price, int publishedYear)
        {
            Title = title;
            Author = author;
            Price = price;
            PublishedYear = publishedYear;
        }
    }
}
