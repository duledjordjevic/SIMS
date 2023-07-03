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
        private IMemberService _memberService;
        private IUserAccountService _userAccountService;
        private IPaymentService _paymentService;
        private IBookService _bookService;
        public LibrarianViewModel(IMemberService memberService, IUserAccountService userAccountService, IPaymentService paymentService, IBookService bookService)
        {
            _memberService = memberService;
            _userAccountService = userAccountService;
            OpenMembersCommand = new RelayCommand(OpenMembers);
            OpenBorrowingCommand = new RelayCommand(OpenBorrowing);
            _paymentService = paymentService;
            _bookService = bookService;
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
            borrowingTableView.DataContext = new BorrowingTableViewModel(borrowingTableView, _bookService, _memberService);
            borrowingTableView.ShowDialog();
        }

    }
}
