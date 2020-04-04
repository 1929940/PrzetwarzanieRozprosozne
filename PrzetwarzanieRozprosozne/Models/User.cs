using System;
using System.Collections.Generic;
using System.Threading;

namespace PrzetwarzanieRozprosozne.Models
{
    public class User
    {
        public int ID { get; set; }
        public List<Book> BooksToRead { get; set; }
        public List<Book> BooksRead { get; set; } = new List<Book>();

        public void ReadBookLock(Book book)
        {
            Console.WriteLine($"User {ID} is attempting to read book {book.ID}.");
            lock (book)
            {
                Console.WriteLine($"User {ID} began reading book {book.ID}");
                Thread.Sleep(book.Pages);
                Console.WriteLine($"User {ID} finished reading book {book.ID}");
                BooksRead.Add(book);
            }
        }

        public void ReadBookSemaphore(Book book)
        {
            Console.WriteLine($"User {ID} is attempting to read book {book.ID}.");
            book.Semaphore.WaitOne();
            Console.WriteLine($"User {ID} began reading book {book.ID}");
            Thread.Sleep(book.Pages);
            Console.WriteLine($"User {ID} finished reading book {book.ID}");
            BooksRead.Add(book);
            book.Semaphore.Release();
        }

        public override string ToString()
        {
            return $"User {ID}";
        }
    }
}
