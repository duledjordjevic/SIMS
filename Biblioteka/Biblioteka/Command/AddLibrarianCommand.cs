using Biblioteka.Model;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Command
{
    public class AddLibrarianCommand : CommandBase
    {
        private LibrarianTableViewModel _librarianTableViewModel;
        private IUserAccountService _userAccountService;

        public AddLibrarianCommand(LibrarianTableViewModel librarianTableViewModel, IUserAccountService userAccountService)
        {
            _librarianTableViewModel = librarianTableViewModel;
            _userAccountService = userAccountService;
            _librarianTableViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        public override bool CanExecute(object? parameter)
        {
            return (_librarianTableViewModel.Email is not null) &&
             (_librarianTableViewModel.Password is not null)&&
             _librarianTableViewModel.SelectedLibrarian != Enums.AccountType.ADMIN;
        }
        public override void Execute(object? parameter)
        {
            var newUser = new UserAccount(_librarianTableViewModel.Email, _librarianTableViewModel.Password, _librarianTableViewModel.SelectedLibrarian);
            _userAccountService.Add(newUser);
            _librarianTableViewModel.Librarians.Add(newUser);
            _librarianTableViewModel.Email = null;
            _librarianTableViewModel.Password = null;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_librarianTableViewModel.Email) ||
                e.PropertyName == nameof(_librarianTableViewModel.SelectedLibrarian) ||
                e.PropertyName == nameof(_librarianTableViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
