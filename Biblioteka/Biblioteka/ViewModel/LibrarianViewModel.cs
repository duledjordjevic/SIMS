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
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class LibrarianViewModel : ViewModelBase
    {
        public ICommand OpenMembersCommand { get; }
        public ICommand OpenBorrowingCommand { get; }
        public ICommand OpenBookReturnCommand { get; }
        private IMemberService _memberService;
        private IUserAccountService _userAccountService;
        private IPaymentService _paymentService;
        private IBookService _bookService;
        private IBorrowingService _borrowingService;
        public LibrarianViewModel(IMemberService memberService, IUserAccountService userAccountService, IPaymentService paymentService, IBookService bookService, IBorrowingService borrowingService)
        {
            _memberService = memberService;
            _userAccountService = userAccountService;
            OpenMembersCommand = new RelayCommand(OpenMembers);
            OpenBorrowingCommand = new RelayCommand(OpenBorrowing);
            OpenBookReturnCommand = new RelayCommand(OpenBookReturn);
            _paymentService = paymentService;
            _bookService = bookService;
            _borrowingService = borrowingService;
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
            bookReturnView.DataContext = new BookReturnViewModel(bookReturnView, _memberService, _bookService, _borrowingService);
            bookReturnView.ShowDialog();
        }
    }
}
