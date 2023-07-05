using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.View.Table;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class LibrarianViewModel : ViewModelBase
    {
        public ICommand OpenMembersCommand { get; }
        public ICommand OpenBorrowingCommand { get; }
        public ICommand OpenBookReturnCommand { get; }
        public ICommand LogOutCommand { get; }
        private IMemberService _memberService;
        private IUserAccountService _userAccountService;
        private IPaymentService _paymentService;
        private IBookService _bookService;
        private IBorrowingService _borrowingService;
        private IReturnBookService _returnBookService;
        private MainViewModel _mainViewModel;
        private ILoginService _loginService;
        public LibrarianViewModel(IMemberService memberService, IUserAccountService userAccountService, IPaymentService paymentService, IBookService bookService, IBorrowingService borrowingService, IReturnBookService returnBookService, MainViewModel mainViewModel, ILoginService loginService)
        {
            _memberService = memberService;
            _userAccountService = userAccountService;
            OpenMembersCommand = new RelayCommand(OpenMembers);
            OpenBorrowingCommand = new RelayCommand(OpenBorrowing);
            OpenBookReturnCommand = new RelayCommand(OpenBookReturn);
            LogOutCommand = new RelayCommand(LogOut);
            _paymentService = paymentService;
            _bookService = bookService;
            _borrowingService = borrowingService;
            _returnBookService = returnBookService;
            _mainViewModel = mainViewModel;
            _loginService = loginService;
        }

        public void OpenMembers()
        {
            var membersView = new MembersTableView();
            membersView.DataContext = new MembersTableViewModel(membersView, _userAccountService,_memberService, _paymentService);
            membersView.ShowDialog();
        }

        public void OpenBorrowing()
        {
            var borrowingTableView = new BorrowingTableView();
            borrowingTableView.DataContext = new BorrowingTableViewModel(borrowingTableView, _bookService, _memberService, _borrowingService);
            borrowingTableView.ShowDialog();
        }

        public void OpenBookReturn()
        {
            var bookReturnView = new BookReturnView();
            bookReturnView.DataContext = new BookReturnViewModel(bookReturnView, _memberService, _bookService, _borrowingService, _returnBookService);
            bookReturnView.ShowDialog();
        }

        public void LogOut()
        {
            MessageBox.Show("Uspesno ste se izlogovali");
            _mainViewModel.CurrentViewModel = new LoginViewModel(_mainViewModel, _loginService);
        }
    }
}
