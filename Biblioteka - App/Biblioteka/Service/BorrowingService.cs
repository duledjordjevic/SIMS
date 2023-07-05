using Biblioteka.Model;
using Biblioteka.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class BorrowingService : IBorrowingService
    {
        private IBorrowingRepository _borrowingRepository;


        public BorrowingService(IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        public void Add(int memberId, string bookCopyInventoryNumber)
        {
            _borrowingRepository.Add(new Borrowing(DateTime.Now, DateTime.Now.AddDays(14), memberId, bookCopyInventoryNumber));
        }

        public bool HasMemberBorrowing(int memberId)
        {
            return _borrowingRepository.GetAll().Values.Any(borrowing => borrowing.MemberId == memberId && borrowing.IsFinished == false && borrowing.Start.Date != DateTime.Now.Date );
        }

        public void Update(Borrowing borrowing)
        {
            _borrowingRepository.Update(borrowing);
        }

        public Dictionary<int, Borrowing> GetAll()
        {
            return _borrowingRepository.GetAll();
        }
        public List<Borrowing> GetAllNotFinished(int memberId)
        {
            return GetAll().Values.Where(b => b.MemberId == memberId && !b.IsFinished).ToList(); ;
        }
    }
}
