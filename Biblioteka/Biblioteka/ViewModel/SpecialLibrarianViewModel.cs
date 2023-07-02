using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.View.Dialog;
using Biblioteka.ViewModel.Dialog;
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
            var addingBookTitleTableView = new AddingBookTitleTableView();
            addingBookTitleTableView.DataContext = new AddingBookTitleTableViewModel(addingBookTitleTableView, _bookService); ;
            addingBookTitleTableView.ShowDialog();
        }
    }
}
