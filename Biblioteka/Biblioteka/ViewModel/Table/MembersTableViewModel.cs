using Biblioteka.Command;
using Biblioteka.Model;
using Biblioteka.Repository;
using Biblioteka.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Table
{
    public class MembersTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Member> _members;
        public ObservableCollection<Member> Members => _members;
        private Member _selectedMember;
        public Member SelectedMember
        {
            get
            {
                return _selectedMember;
            }
            set
            {
                _selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }
        private IMemberService _memberService;
        public ICommand OpenAddMemberCommand { get; }
        public ICommand CloseCommand { get; }
        public MembersTableViewModel(Window window, IMemberService memberService)
        {
            _memberService = memberService;
            _members = new ObservableCollection<Member>();
            LoadMembers();
            OpenAddMemberCommand = new RelayCommand(OpenAddMember);
            CloseCommand = new CloseCommand(window);
        }

        private void OpenAddMember()
        {
           
        }

        private void LoadMembers()
        {
            _members.Clear();
            foreach(var member in _memberService.GetAll().Values)
            {
                _members.Add(member);
            }
        }
    }
}
