using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IBookTitleRepository
    {
        void Add(BookTitle book);
        BookTitle Get(int id);
        Dictionary<int, BookTitle> GetAll();
        void Remove(int id);
        void Update(BookTitle book);
    }
}