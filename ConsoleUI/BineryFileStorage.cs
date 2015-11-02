using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService;

namespace ConsoleUI
{
    class BineryFileStorage : StorageAdapter
    {
        private string path = "F:\\C#\\ASP.NETtraining\\Projects\\Day5\\BSU.ASP.NET.Sokolov.Day5\\data.bin";

        public BineryFileStorage()
        {
            if(!File.Exists(path))
                using (File.Create(path)) {}
        }
        public List<Book> Load()
        {
            List<Book> books = new List<Book>();
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fsRead))
                {
                    while (reader.PeekChar() != -1)
                    {
                        Book book = new Book
                        (
                            reader.ReadString(),
                            reader.ReadString(),
                            reader.ReadInt32(),
                            reader.ReadString()
                        );
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public void Save(List<Book> books)
        {
            using (FileStream fsWrite = new FileStream(path, FileMode.Truncate, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(fsWrite))
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
}
