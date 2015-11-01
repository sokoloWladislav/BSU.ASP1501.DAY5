using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class BookListService
    {
        public enum Tags {Title, Author, Year, Languadge};
        public static void AddBook(Stream sWrite, List<Book> books, Book book)
        {
            if (books.Contains(book))
                throw new ArgumentException("The book which to be added is already exist");
            using (var writer = new BinaryWriter(sWrite))
            {
                writer.Write(book.Title);
                writer.Write(book.Author);
                writer.Write(book.Year);
                writer.Write(book.Languadge);
                writer.Flush();
            }
        }

        public static void RemoveBook(Stream sWrite, List<Book> books, Book book)
        {
            books.Remove(book);
            WriteAllBooks(sWrite, books);
        }

        /*public Book FindByTag(Tags tag, string str)
        {
            
        }

        public void SortBooksByTag()
        {
            
        }*/

        public static List<Book> ReadAllBooks(Stream s)
        {
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(s))
            {
                while (reader.PeekChar() != -1)
                {
                    string title = reader.ReadString();
                    string author = reader.ReadString();
                    int year = reader.ReadInt32();
                    string languadge = reader.ReadString();
                    books.Add(new Book(title, author, year, languadge));
                }
            }
            return books;
        }

        public static void WriteAllBooks(Stream s, List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Year);
                    writer.Write(book.Languadge);
                }
                writer.Flush();
            }
        }
    }
}
