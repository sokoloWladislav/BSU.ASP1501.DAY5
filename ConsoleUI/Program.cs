using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.CurrentDirectory = "F:\\C#\\ASP.NETtraining\\Projects\\Day5\\BSU.ASP.NET.Sokolov.Day5\\";
            Book a = new Book("Anna Korenina", "Tolstoy", 1785, "russian");
            Book b = new Book("Idiot", "Dostoevsky", 1755, "russian");
            Book c = new Book("Misery", "Stiven King", 1958, "english");
            //AddBook(a);
            //AddBook(b);
            //AddBook(c);
            //RemoveBook(b);
            FileStream fsRead = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            Show(fsRead);
            Console.ReadKey();
        }

        public static void AddBook(Book book)
        {
            if (!File.Exists("data.bin"))
                using (FileStream fs = File.Create("data.bin"));
            FileStream fsRead2 = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            List<Book> books = BookListService.ReadAllBooks(fsRead2);
            FileStream fsWrite = new FileStream("data.bin", FileMode.Append, FileAccess.Write);
            BookListService.AddBook(fsWrite, books, book);
        }

        public static void RemoveBook(Book book)
        {
            FileStream fsRead = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            List<Book> books = BookListService.ReadAllBooks(fsRead);
            if (!books.Contains(book))
                throw new ArgumentException("The book which to be removed is not finded");
            FileStream fsWrite = new FileStream("data.bin", FileMode.Open, FileAccess.Write);
            BookListService.RemoveBook(fsWrite, books, book);
        }

        public static void Show(Stream sRead)
        {
            List<Book> books = BookListService.ReadAllBooks(sRead);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
