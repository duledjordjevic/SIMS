using Biblioteka.Enums;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class ReturnBookService 
    {
        private IBookService _bookService;
        private IBorrowingService _borrowingService;
        private IPaymentService _paymentService;

        public ReturnBookService(IBookService bookService, IBorrowingService borrowingService, IPaymentService paymentService)
        {
            _bookService = bookService;
            _borrowingService = borrowingService;
            _paymentService = paymentService;
        }

        public double ReturnWithTotalDamage(Borrowing borrowing, BookCopy bookCopy,int bookTitleId, int memberId)
        {
            borrowing.IsFinished = true;
            _borrowingService.Update(borrowing);
            bookCopy.BookCopyStatus = BookCopyStatus.UNUSABLE;
            _bookService.UpdateBookCopy(bookCopy, bookTitleId);
            _paymentService.Add(new Payment(PaymentType.TOTAL_BOOK_DAMAGE, bookCopy.PurchasePrice, DateTime.Now, memberId));
            return bookCopy.PurchasePrice;
        }

        public void ReturnWithDamage(Borrowing borrowing, BookCopy bookCopy, int bookTitleId, double price, int memberId)
        {
            borrowing.IsFinished = true;
            _borrowingService.Update(borrowing);
            bookCopy.BookCopyStatus = BookCopyStatus.AVAILABLE;
            _bookService.UpdateBookCopy(bookCopy, bookTitleId);
            _paymentService.Add(new Payment(PaymentType.BOOK_DAMAGE, bookCopy.PurchasePrice, DateTime.Now, memberId));
        }

        public void ReturnWithNoDamage(Borrowing borrowing, BookCopy bookCopy, int bookTitleId, )
        {
            borrowing.IsFinished = true;
            _borrowingService.Update(borrowing);
            bookCopy.BookCopyStatus = BookCopyStatus.AVAILABLE;
            _bookService.UpdateBookCopy(bookCopy, bookTitleId);
        }

        public double PayForLate(Borrowing borrowing, int memberId)
        {
            double price = 0;
            if(borrowing.End < DateTime.Now)
            {
                price = 10 * (DateTime.Now - borrowing.End).Days;
                _paymentService.Add(new Payment(PaymentType.LATE_FEE, price, DateTime.Now, memberId));
            }

            return price;
        }
    }
}
