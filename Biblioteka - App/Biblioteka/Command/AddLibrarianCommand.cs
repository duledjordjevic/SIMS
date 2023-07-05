using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel.Dialog;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            if (!_userAccountService.IsEmailValid(_librarianTableViewModel.Email))
            {
                OnExecutionCompleted(false, "Email je u losem formatu.");
                return;
            }
            else if (_userAccountService.CheckUserExistanceEmail(_librarianTableViewModel.Email))
            {
                OnExecutionCompleted(false, "Korisnik sa ovom email adresom vec postoji");
                return;
            }
            var newUser = new UserAccount(_librarianTableViewModel.Email, _librarianTableViewModel.Password, _librarianTableViewModel.SelectedLibrarian);
            _userAccountService.Add(newUser);
            _librarianTableViewModel.Librarians.Add(newUser);
            _librarianTableViewModel.Email = "";
            _librarianTableViewModel.Password = "";
            OnExecutionCompleted(true, "Uspesno ste dodali bibliotekara");
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
