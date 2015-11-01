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
            Book a = new Book("Anna Korenina", "Tolstoy", 1878, "russian");
            Book b = new Book("Idiot", "Dostoevsky", 1868, "russian");
            Book c = new Book("Misery", "Stiven King", 1987, "english");
            Book d = new Book("It", "Stiven King", 1985, "english");
            BineryFileStorage data = new BineryFileStorage();
            BookListService dataService = new BookListService(data);
            dataService.AddBook(a);
            dataService.AddBook(b);
            dataService.AddBook(c);
            dataService.AddBook(d);
            dataService.RemoveBook(a);
            Show(data.Load());
            dataService.SortBooksByTag(BookListService.Tags.Year);
            Show(data.Load());
            Show(dataService.FindByTag(BookListService.Tags.Year, 1985));
            
        }

        public static void Show(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            Console.ReadKey();
        }
    }
}
