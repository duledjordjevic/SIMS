using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Repository;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Table
{
    public class LibrarianTableViewModel:ViewModelBase
    {
		private String _email;
		public String Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}
		private String _password;
		public String Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}
        public ObservableCollection<AccountType> LibrarianTypes { get; set; }
		private AccountType _selectedLibrarian;
		public AccountType SelectedLibrarian
        {
			get
			{
				return _selectedLibrarian;
			}
			set
			{
				_selectedLibrarian = value;
				OnPropertyChanged(nameof(SelectedLibrarian));
			}
		}
		public CommandBase AddLibrarianCommand { get; }
		private ObservableCollection<UserAccount> _librarians;
		public ObservableCollection<UserAccount> Librarians
        {
			get
			{
				return _librarians;
			}
			set
			{
                _librarians = value;
				OnPropertyChanged(nameof(Librarians));
			}
		}
		private IUserAccountService _userAccountService;
		public LibrarianTableViewModel(IUserAccountService userAccountService)
		{
			_userAccountService = userAccountService;
			_librarians = new ObservableCollection<UserAccount>();
			LoadLibrarians();
            var allTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToList();
			allTypes.Remove(AccountType.ADMIN);
			allTypes.Remove(AccountType.MEMBER);
            LibrarianTypes = new ObservableCollection<AccountType>(allTypes);
			AddLibrarianCommand = new AddLibrarianCommand(this,userAccountService);
            AddLibrarianCommand.ExcecutionCompleted += AddLibrarianExecutionCompleted;
        }

		public void LoadLibrarians()
		{
            var librarians = _userAccountService.GetAll().
				Select(o => o.Value).Where(g => g.AccountType == AccountType.LIBRARIAN || g.AccountType == AccountType.SPECIAL_LIBRARIAN).ToList();
			_librarians.Clear();
            foreach(var librarian in librarians)
			{
				_librarians.Add(librarian);
			}
        }
        private void AddLibrarianExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadLibrarians();
            }
            else
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
