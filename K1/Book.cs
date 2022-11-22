using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K1
{
    internal class Book
    {
        public string Publisher { get; set; }
        public string Title { get; set; }
        public int BookCount { get; set; }
        public decimal Price { get; set; }

        public Book(string publisher, string title, int bookCount, decimal price)
        {
            this.Publisher = publisher;
            this.Title = title;
            this.BookCount = bookCount;
            this.Price = price;
        }
        public Book(string title, int bookCount, decimal price)
        {
            this.Title = title;
            this.BookCount = bookCount;
            this.Price = price;
        }
        
    }
}
