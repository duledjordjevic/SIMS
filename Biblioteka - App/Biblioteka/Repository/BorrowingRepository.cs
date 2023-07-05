using Biblioteka.Model;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private ICRUDRepository<Borrowing> _repo;
        public BorrowingRepository(ICRUDRepository<Borrowing> repo)
        {
            _repo = repo;
        }

        public void Add(Borrowing borrowing)
        {
            _repo.Add(borrowing);
        }

        public void Update(Borrowing borrowing)
        {
            _repo.Update(borrowing);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Borrowing Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Borrowing> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Borrowing> GetAllNotFinished(int memberId)
        {
            return GetAll().Values.Where(b => b.MemberId == memberId && !b.IsFinished).ToList(); ;
        }
    }
}
