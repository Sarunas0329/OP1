using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K1
{
    internal class BookStore
    {
        private List<Book> AllBooks;
        public BookStore(List<Book> Books)
        {
            AllBooks = new List<Book>();
            foreach (Book book in Books)
            {
                this.AllBooks.Add(book);
            }
        }
        public BookStore()
        {
            AllBooks = new List<Book>();
        }

        public void Add(Book book)
        {
            AllBooks.Add(book);
        }
        public Book GetBook(int index)
        {
            return AllBooks[index];
        }
        public int GetCount()
        {
            return AllBooks.Count;
        }
        public void AddBook(Book books)
        {
            AllBooks.Add(books);
        }

        public decimal Sum()
        {
            decimal sum = 0;
            foreach(Book book in AllBooks)
            {
                sum += book.BookCount * book.Price;
            }
            return sum;
        }
        public int IndexMaxPrice(Book book)
        {
            decimal max = 0;
            int index = 0;
            for (int i = 0; i < GetCount(); i++)
            {
                if(GetBook(i).Title == book.Title)
                {
                    if (AllBooks[i].Price > max)
                    {
                        if(AllBooks[i].BookCount > 0)
                        {
                            max = AllBooks[i].Price;
                            index = i;
                        }
                        
                    }
                }

            }
            return index;
        }
        public void AddSalePrice(List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                int index = IndexMaxPrice(books[i]);
                books[i].Price = GetBook(index).Price;
                AllBooks[index].BookCount--;
            }
        }
    }
}
