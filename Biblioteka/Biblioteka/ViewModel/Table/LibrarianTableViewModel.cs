using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Repository;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public ICommand AddLibrarianCommand { get; }
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
		public LibrarianTableViewModel(IUserAccountService userAccountService)
		{
			var librarian = userAccountService.GetAll().Select(o => o.Value).Where(g => g.AccountType == AccountType.LIBRARIAN || g.AccountType == AccountType.SPECIAL_LIBRARIAN).ToList();
			_librarians = new ObservableCollection<UserAccount>(librarian);
			var allTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToList();
			allTypes.Remove(AccountType.ADMIN);
			allTypes.Remove(AccountType.MEMBER);
            LibrarianTypes = new ObservableCollection<AccountType>(allTypes);
			AddLibrarianCommand = new AddLibrarianCommand(this,userAccountService);
		}
	}
}
