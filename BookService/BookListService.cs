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
        private List<Book> books;
        private StorageAdapter storageAdapter;

        private delegate bool EquivalenceCompareKey(Book book, string name);
        public enum Tags {Title, Author, Year, Languadge};

        public BookListService(StorageAdapter storageAdapter)
        {
            this.storageAdapter = storageAdapter;
        }
        public void AddBook(Book book)
        {
            books = storageAdapter.Load();
            if (books.Contains(book))
                throw new ArgumentException("The book which to be added is already exist");
            books.Add(book);
            Commit();
        }

        public void RemoveBook(Book book)
        {
            books = storageAdapter.Load();
            if (!books.Contains(book))
                throw new ArgumentException("The book which to be removed is not finded");
            books.Remove(book);
            Commit();
        }

        public List<Book> FindByTag(Tags tag, int name)
        {
            return FindByTag(tag, name.ToString());
        }

        public List<Book> FindByTag(Tags tag, string name)
        {
            books = storageAdapter.Load();
            EquivalenceCompareKey key;
            switch (tag)
            {
                case Tags.Title:
                    key = FindByTitle;
                    break;
                case Tags.Author:
                    key = FindByAuthor;
                    break;
                case Tags.Year:
                    key = FindByYear;
                    break;
                case Tags.Languadge:
                    key = FindByLanguadge;
                    break;
                default:
                    key = FindByTitle;
                    break;
            }
            return Find(key, name);
        }

        public void SortBooksByTag(Tags tag)
        {
            books = storageAdapter.Load();
            Comparison<Book> comparison;
            switch (tag)
            {
                case Tags.Title:
                    comparison = Book.CompareByTitle;
                    break;
                case Tags.Author:
                    comparison = Book.CompareByAuthor;
                    break;
                case Tags.Year:
                    comparison = Book.CompareByYear;
                    break;
                case Tags.Languadge:
                    comparison = Book.CompareByLanguadge;
                    break;
                default:
                    comparison = Book.CompareByTitle;
                    break;
            }
            books.Sort(comparison);
            Commit();
        }

        private void Commit()
        {
            storageAdapter.Save(books);
        }

        private List<Book> Find(EquivalenceCompareKey key, string name)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if(key(book, name))
                    result.Add(book);
            }
            return result;
        }

        private bool FindByTitle(Book book, string title)
        {
            return book.Title == title;
        }

        private bool FindByAuthor(Book book, string author)
        {
            return book.Author == author;
        }

        private bool FindByYear(Book book, string year)
        {
            return book.Year == Int32.Parse(year);
        }

        private bool FindByLanguadge(Book book, string languadge)
        {
            return book.Languadge == languadge;
        }
    }
}
