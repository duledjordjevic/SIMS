using Biblioteka.Command;
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
    public class AdminViewModel : ViewModelBase
    {
        public ICommand OpenAddLibrarianCommand { get; }
        private IUserAccountService _userAccountService;
        public AdminViewModel(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
            OpenAddLibrarianCommand = new RelayCommand(OpenAddLibrarian, CanClick);
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenAddLibrarian()
        {
            var librarianTableView = new LibrarianTableView();
            librarianTableView.DataContext = new LibrarianTableViewModel(_userAccountService);
            librarianTableView.Show();
        }
    }
}
