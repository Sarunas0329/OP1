using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace K1
{
    internal class InOutUtils
    {
        public static BookStore InputBooks(string fileName)
        {
            BookStore Books = new BookStore();
            string[] lines = File.ReadAllLines(fileName);
            foreach(string line in lines)
            {
                string[] Values = line.Split(';');
                string publisher = Values[0];
                string title = Values[1];
                int bookCount = int.Parse(Values[2]);
                decimal price = decimal.Parse(Values[3]);

                Book book = new Book(publisher, title, bookCount, price);
                Books.Add(book);
            }
            return Books;
        }
        public static List<Book> InputSoldBooks(string fileName)
        {
            List<Book> Books = new List<Book>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string title = line;

                Book book = new Book(title, 1, 0);
                Books.Add(book);
            }
            return Books;
        }
        public static void Print(BookStore books, string fileName, string header)
        {
            string[] lines = new string[books.GetCount()+4];
            lines[0] = String.Format(header);
            lines[1] = String.Format(new String('-', 69));
            lines[2] = String.Format("{0,15} {1,20} {2,13} {3,15}", "Platintojas", "Pavadinimas", "Kiekis", "Kaina");
            lines[3] = String.Format(new String('-', 69));
            for (int i = 0; i < books.GetCount(); i++)
            {
                Book book = books.GetBook(i);
                lines[i + 3] = String.Format("| {0,-15} | {1,-20} | {2,10} | {3,10:c}  |", book.Publisher, book.Title, book.BookCount, book.Price);
            }
            lines[books.GetCount() + 3] = String.Format(new String('-', 69));
            File.AppendAllLines(fileName, lines);

        }
        public static void Print(List<Book> books, string fileName, string header)
        {
            string[] lines = new string[books.Count + 4];
            lines[0] = String.Format(header);
            lines[1] = String.Format(new String('-', 45));
            lines[2] = String.Format("{0,15} {1,10} {2,15} ", "Pavadinimas", "Kiekis", "Kaina");
            lines[3] = String.Format(new String('-', 45));
            for (int i = 0; i < books.Count; i++)
            {
                lines[i+3] = String.Format("| {0,-15} | {1,10} | {2,10:c} |", books[i].Title, books[i].BookCount, books[i].Price);
            }
            lines[books.Count + 3] = String.Format(new String('-', 45));
            File.AppendAllLines(fileName, lines);

        }
    }
}
