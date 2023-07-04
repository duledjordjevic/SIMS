using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.View.Dialog;
using Biblioteka.View.Table;
using Biblioteka.ViewModel.Dialog;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class SpecialLibrarianViewModel : ViewModelBase
    {
        public ICommand OpenBooksCommand { get; }
        public ICommand LogOutCommand { get; }
        private IBookService _bookService;
        private MainViewModel _mainViewModel;
        private ILoginService _loginService;
        public SpecialLibrarianViewModel(IBookService bookService, MainViewModel mainViewModel, ILoginService loginService)
        {
            _bookService = bookService;
            OpenBooksCommand = new RelayCommand(OpenBooks, CanClick);
            LogOutCommand = new RelayCommand(LogOut);
            _mainViewModel = mainViewModel;
            _loginService = loginService;
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenBooks()
        {
            var bookTableView = new BookTableView();
            bookTableView.DataContext = new BookTableViewModel(bookTableView, _bookService);
            bookTableView.ShowDialog();
        }

        public void LogOut()
        {
            MessageBox.Show("Uspesno ste se izlogovali");
            _mainViewModel.CurrentViewModel = new LoginViewModel(_mainViewModel, _loginService);
        }
    }
}
