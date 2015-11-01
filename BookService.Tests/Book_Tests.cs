using System;
using NUnit.Framework;
using BookService;

namespace BookService.Tests
{
    [TestFixture]
    public class Book_Tests
    {
        [Test]
        public void TestCompareTo()
        {
            Book a = new Book("Anna Korenina", "Tolstoy", 1785, "russian");
            Book b = new Book("Idiot", "Dostoevsky", 1755, "russian");
            Book c = new Book("Anna Korenina", "Tolstoy", 1785, "russian");

            Assert.AreEqual(0, a.CompareTo(c));
            Assert.AreEqual(-1, a.CompareTo(b));
        }
    }
}