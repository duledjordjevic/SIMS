using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.View.Dialog;
using Biblioteka.View.Table;
using Biblioteka.ViewModel.Dialog;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class SpecialLibrarianViewModel : ViewModelBase
    {
        public ICommand OpenBooksCommand { get; }
        private IBookService _bookService;
        public SpecialLibrarianViewModel(IBookService bookService)
        {
            _bookService = bookService;
            OpenBooksCommand = new RelayCommand(OpenBooks, CanClick);
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
    }
}
