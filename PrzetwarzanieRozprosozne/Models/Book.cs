using System;
using System.Threading;

namespace PrzetwarzanieRozprosozne.Models
{
    public class Book
    {
        public int Pages { get; set; }
        public int ID { get; set; }
        public Semaphore Semaphore { get; set; }

        public Book(int id)
        {
            ID = id;
            Pages = Generator.RandomGenerator.Next(20, 600);
            Semaphore = new Semaphore(4, 4);
        }

        public override string ToString()
        {
            return $"Book {ID}, Pages {Pages}";
        }
    }
}
