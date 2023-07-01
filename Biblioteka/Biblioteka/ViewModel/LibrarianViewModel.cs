using Biblioteka.Command;
using Biblioteka.Service;
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
        public LibrarianViewModel(IMemberService memberService)
        {
            _memberService = memberService;
            OpenMembersCommand = new RelayCommand(OpenMembers, CanClick);
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenMembers()
        {
            var membersView = new MembersTableView();
            membersView.DataContext = new MembersTableViewModel(membersView, _memberService);
            membersView.ShowDialog();
        }
    }
}
