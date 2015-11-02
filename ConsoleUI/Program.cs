using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService;
using NLog;

namespace ConsoleUI
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {

                logger.Trace("Начало работы программы");
                logger.Trace("Создание книг начато");
                Book a = new Book("Anna Korenina", "Tolstoy", 1878, "russian");
                Book b = new Book("Idiot", "Dostoevsky", 1868, "russian");
                Book c = new Book("Misery", "Stiven King", 1987, "english");
                Book d = new Book("It", "Stiven King", 1985, "english");
                logger.Trace("Создание книг завершено");
                BineryFileStorage data = new BineryFileStorage();
                BookListService dataService = new BookListService(data);
                logger.Trace("Добавление книг начато");
                dataService.AddBook(a);
                dataService.AddBook(b);
                dataService.AddBook(c);
                dataService.AddBook(d);
                logger.Trace("Добавление книг завершено");
                logger.Trace("Удаляется книга");
                dataService.RemoveBook(a);
                Show(data.Load());
                dataService.SortBooksByTag(BookListService.Tags.Year);
                Show(data.Load());
                Show(dataService.FindByTag(BookListService.Tags.Year, 1985));
            }
            catch (ArgumentException e)
            {
                logger.Error(e.ToString());
            }

            
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
