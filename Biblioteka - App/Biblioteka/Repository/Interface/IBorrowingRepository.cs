using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IBorrowingRepository
    {
        void Add(Borrowing borrowing);
        Borrowing Get(int id);
        Dictionary<int, Borrowing> GetAll();
        List<Borrowing> GetAllNotFinished(int memberId);
        void Remove(int id);
        void Update(Borrowing borrowing);
    }
}