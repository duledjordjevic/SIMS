using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        Author Get(int id);
        Dictionary<int, Author> GetAll();
        void Remove(int id);
        void Update(Author author);
    }
}