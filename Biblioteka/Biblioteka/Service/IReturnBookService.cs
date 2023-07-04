using Biblioteka.Model;

namespace Biblioteka.Service
{
    public interface IReturnBookService
    {
        double PayForLate(Borrowing borrowing, int memberId);
        void ReturnWithDamage(Borrowing borrowing, BookCopy bookCopy, int bookTitleId, double price, int memberId);
        void ReturnWithNoDamage(Borrowing borrowing, BookCopy bookCopy, int bookTitleId);
        double ReturnWithTotalDamage(Borrowing borrowing, BookCopy bookCopy, int bookTitleId, int memberId);
    }
}