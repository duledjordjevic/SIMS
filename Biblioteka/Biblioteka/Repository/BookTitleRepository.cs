using Biblioteka.Model;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    public class BookTitleRepository
    {
        private ICRUDRepository<BookTitle> _repo;
        public BookTitleRepository(ICRUDRepository<BookTitle> repo)
        {
            _repo = repo;
        }

        public void Add(BookTitle book)
        {
            _repo.Add(book);
        }

        public void Update(BookTitle book)
        {
            _repo.Update(book);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public BookTitle Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, BookTitle> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
