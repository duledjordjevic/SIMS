using Biblioteka.Command;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.View.Dialog;
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
    public class BookCopiesTableViewModel : ViewModelBase
    {
		private ObservableCollection<BookCopy> _bookCopies;
		public ObservableCollection<BookCopy> BookCopies
		{
			get
			{
				return _bookCopies;
			}
			set
			{
                _bookCopies = value;
				OnPropertyChanged(nameof(BookCopies));
			}
		}

		public ICommand OpenAddBookCopyCommand { get; }
		public ICommand CloseCommand { get; }
		private IBookService _bookService;
		private int _bookTitleId;
        public BookCopiesTableViewModel(Window window, IBookService bookService, int bookTitleId)
        {
			_bookService = bookService;
			_bookTitleId = bookTitleId;
			BookCopies = new ObservableCollection<BookCopy>();
			LoadBookCopies();
			OpenAddBookCopyCommand = new RelayCommand(OpenAddBookCopy);
            CloseCommand = new CloseCommand(window);
        }

		public void LoadBookCopies()
		{
			BookCopies.Clear();
			var bookCopies = _bookService.GetAllBookCopies(_bookTitleId);
			if (bookCopies is not null)
			{
				foreach (var bookCopy in bookCopies)
				{
					BookCopies.Add(bookCopy);
				}
			}
		}

		public void OpenAddBookCopy()
		{
			var addingBookCopyDialogView = new AddingBookCopyDialogView();
			addingBookCopyDialogView.DataContext = new AddingBookCopyDialogViewModel(addingBookCopyDialogView,this, _bookService, _bookTitleId);
			addingBookCopyDialogView.ShowDialog();
		}
    }
}
