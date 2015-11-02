using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public interface StorageAdapter
    {
        List<Book> Load();
        void Save(List<Book> books);
    }
}
