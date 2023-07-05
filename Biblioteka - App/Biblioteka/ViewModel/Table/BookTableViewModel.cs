using Biblioteka.Command;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.View.Dialog;
using Biblioteka.View.Table;
using Biblioteka.ViewModel.Dialog;
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
    public class BookTableViewModel : ViewModelBase
    {
		private ObservableCollection<BookTitle> _bookTitles;
		public ObservableCollection<BookTitle> BookTitles
		{
			get
			{
				return _bookTitles;
			}
			set
			{
                _bookTitles = value;
				OnPropertyChanged(nameof(BookTitles));
			}
		}
		private BookTitle _selectedBookTitle;
		public BookTitle SelectedBookTitle
		{
			get
			{
				return _selectedBookTitle;
			}
			set
			{
                _selectedBookTitle = value;
				OnPropertyChanged(nameof(SelectedBookTitle));
			}
		}

		public ICommand OpenAddBookTitleCommand { get; }
		public ICommand OpenAddBookCopyCommand { get; }
		public ICommand CloseCommand { get; }
		private IBookService _bookService;
        public BookTableViewModel(Window window, IBookService bookService)
        {
			_bookService = bookService;
			BookTitles = new ObservableCollection<BookTitle>();
			LoadBooks();
            OpenAddBookTitleCommand = new RelayCommand(OpenAddBookTitle);
			OpenAddBookCopyCommand = new RelayCommand(OpenAddBookCopy, CanOpenAddBookCopy);
            CloseCommand = new CloseCommand(window);
        }

		public void OpenAddBookTitle()
		{
			var addingBookTitleTableView = new AddingBookTitleDialogView();
			addingBookTitleTableView.DataContext = new AddingBookTitleDialogViewModel(addingBookTitleTableView,this, _bookService); ;
			addingBookTitleTableView.ShowDialog();
		}

		public void LoadBooks()
		{
			BookTitles.Clear();
			foreach(var book in _bookService.GetAllBookTitles().Values)
			{
				BookTitles.Add(book);
			}
		}

		public bool CanOpenAddBookCopy()
		{
			return SelectedBookTitle is not null;
		}

		public void OpenAddBookCopy()
		{
			var bookCopiesTableView = new BookCopiesTableView();
			bookCopiesTableView.DataContext = new BookCopiesTableViewModel(bookCopiesTableView, _bookService, SelectedBookTitle.Id);
			bookCopiesTableView.ShowDialog();
		}
    }
}
