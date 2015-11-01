using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Languadge { get; set; }

        public Book(string title, string author, int year, string languadge)
        {
            Title = title;
            Author = author;
            Year = year;
            Languadge = languadge;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Author == other.Author && Title == other.Title && Year == other.Year && Languadge == other.Languadge)
                return true;
            return false;
        }

        public int CompareTo(Book other)
        {
            int result = String.Compare(Title, other.Title);
            if (result == 0)
            {
                result = String.Compare(Author, other.Author);
                if (result == 0)
                {
                    if (Year < other.Year)
                        result = 1;
                    if (Year > other.Year)
                        result = -1;
                    if (Year == other.Year)
                        result = String.Compare(Languadge, other.Languadge);
                }
            }
            return result;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}, Author: {1}, Year: {2}, Languadge: {3}", Title, Author, Year, Languadge);
        }
    }
}
