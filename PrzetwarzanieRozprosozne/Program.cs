using PrzetwarzanieRozprosozne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PrzetwarzanieRozprosozne
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<Book> books = Generator.GenerateBooks(200);
            List<User> users = Generator.GenerateUsers(40, books);

            var tasks = new Task[users.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                int index = i;
                //tasks[index] = Task.Run(() => users[index].BooksToRead.ForEach(x => users[index].ReadBookLock(x)));
                tasks[index] = Task.Run(() => users[index].BooksToRead.ForEach(x => users[index].ReadBookSemaphore(x)));
            }
            Task.WaitAll(tasks);

            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Console.WriteLine("All books have been read");
        }
    }
}

