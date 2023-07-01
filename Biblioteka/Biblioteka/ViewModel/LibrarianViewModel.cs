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
        private IMemberService _memberService;
        private IUserAccountService _userAccountService;
        private IPaymentService _paymentService;
        public LibrarianViewModel(IMemberService memberService, IUserAccountService userAccountService, IPaymentService paymentService)
        {
            _memberService = memberService;
            _userAccountService = userAccountService;
            OpenMembersCommand = new RelayCommand(OpenMembers, CanClick);
            _paymentService = paymentService;
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenMembers()
        {
            var membersView = new MembersTableView();
            membersView.DataContext = new MembersTableViewModel(membersView, _userAccountService,_memberService, _paymentService);
            membersView.ShowDialog();
        }
    }
}
