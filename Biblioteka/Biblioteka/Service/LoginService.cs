using Biblioteka.Repository.Interface;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteka.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMemberService _memberService;
        private readonly IPaymentService _paymentService;
        private readonly IBookService _bookService;
        private readonly IBorrowingService _borrowingService;
        private readonly IReturnBookService _returnBookService;
        public LoginService(IUserAccountService userAccountService, IMemberService memberService, IPaymentService paymentService, IBookService bookService, IBorrowingService borrowingService, IReturnBookService returnBookService) 
        {
            _userAccountService = userAccountService;
            _memberService = memberService;
            _paymentService = paymentService;
            _bookService = bookService;
            _borrowingService = borrowingService;
            _returnBookService = returnBookService;
        }
        public void Login(string email, string password, MainViewModel mainViewModel)
        {
            foreach(var account in _userAccountService.GetAll().Values)
            {
                if (account.Email == email && account.Password == password)
                {
                    if (account.AccountType == Enums.AccountType.ADMIN)
                    {
                        mainViewModel.CurrentViewModel = new AdminViewModel(_userAccountService, _paymentService);
                    }
                    else if (account.AccountType == Enums.AccountType.LIBRARIAN)
                    {
                        mainViewModel.CurrentViewModel = new LibrarianViewModel(_memberService, _userAccountService, _paymentService, _bookService, _borrowingService, _returnBookService);
                    }
                    else if (account.AccountType == Enums.AccountType.SPECIAL_LIBRARIAN)
                    {
                        mainViewModel.CurrentViewModel = new SpecialLibrarianViewModel(_bookService);
                    }
                    else
                    {
                        mainViewModel.CurrentViewModel = new MemberViewModel();
                        MessageBox.Show(_memberService.GetByAccountId(account.Id).Adress.City);
                    }
                }
                else
                {
                    MessageBox.Show("Lose uneti podaci");
                }
            }
        }

        //private bool IsValidPassword(Person? user, string password)
        //{
        //    return user is not null && user.Password == password;
        //}
    }
}
