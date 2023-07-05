using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service
{
    public interface IBorrowingService
    {
        void Add(int memberId, string bookCopyInventoryNumber);
        List<Borrowing> GetAllNotFinished(int memberId);
        bool HasMemberBorrowing(int memberId);
        void Update(Borrowing borrowing);
    }
}