using PrzetwarzanieRozprosozne.Models;
using System;
using System.Collections.Generic;

namespace PrzetwarzanieRozprosozne
{
    public static class Generator
    {
        public static Random RandomGenerator { get; set; }

        static Generator()
        {
            RandomGenerator = new Random();
        }

        public static List<Book> GenerateBooks(int noBooks)
        {
            List<Book> books = new List<Book>(noBooks);
            for (int i = 1; i <= noBooks; i++)
            {
                books.Add(new Book(i));
            }
            return books;
        }


        private static List<Book> GetRandomBooks(int noBooks, List<Book> books)
        {
            List<Book> randomBooks = new List<Book>(noBooks);
            HashSet<int> bookIDs = new HashSet<int>();
            while (bookIDs.Count < noBooks)
            {
                bookIDs.Add(RandomGenerator.Next(1, 200));
            }
            foreach (int id in bookIDs)
            {
                randomBooks.Add(books[id]);
            }

            return randomBooks;
        }

        public static List<User> GenerateUsers(int noUsers, List<Book> books)
        {
            List<User> users = new List<User>(noUsers);
            for (int i = 1; i <= noUsers; i++)
            {
                users.Add(new User()
                {
                    ID = i,
                    BooksToRead = GetRandomBooks(40, books)
                });
            }
            return users;
        }
    }
}
