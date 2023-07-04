using Biblioteka.Command;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.ViewModel.Structures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace Biblioteka.ViewModel.Table
{
    public class BookReturnViewModel : ViewModelBase
    {
        private ObservableCollection<Member> _members;
        public ObservableCollection<Member> Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }
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
        private string _searchMembers;
        public string SearchMembers
        {
            get
            {
                return _searchMembers;
            }
            set
            {
                _searchMembers = value;
                OnPropertyChanged(nameof(SearchMembers));
            }
        }

        private IMemberService _memberService;
        private IBookService _bookService;
        private IBorrowingService _borrowingService;
        public ICommand OpenMemberBorrowingsCommand { get; }
        public ICommand CloseCommand { get; }

        public BookReturnViewModel(Window window, IMemberService memberService, IBookService bookService, IBorrowingService borrowingService)
        {
            _memberService = memberService;
            _bookService = bookService;
            _borrowingService = borrowingService;
            Members = new ObservableCollection<Member>();
            LoadMembers();
            OpenMemberBorrowingsCommand = new RelayCommand(OpenMemberBorrowings, CanOpenBorrowings);
            CloseCommand = new CloseCommand(window);
            PropertyChanged += OnPropertyChanged;
        }

        public void LoadMembers()
        {
            Members.Clear();
            foreach (var member in _memberService.GetAll().Values)
            {
                Members.Add(member);
            }
        }
        public bool CanOpenBorrowings()
        {
            return SelectedMember is not null;
        }
        public void OpenMemberBorrowings()
        {

        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchMembers))
            {
                if (!string.IsNullOrEmpty(SearchMembers))
                {
                    var filteredMembers = Members.Where(member => member.Name.ToLower().Contains(SearchMembers.ToLower())
                    || member.LastName.ToLower().Contains(SearchMembers.ToLower())
                    || member.Jmbg.ToLower().Contains(SearchMembers.ToLower())).ToList();
                    Members.Clear();
                    foreach (var member in filteredMembers)
                    {
                        Members.Add(member);
                    }
                }
                else
                {
                    LoadMembers();
                }
            }

        }
    }
}
