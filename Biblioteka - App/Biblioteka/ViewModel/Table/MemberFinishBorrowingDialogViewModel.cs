using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.ViewModel.Structures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Table
{
    public class MemberFinishBorrowingDialogViewModel : ViewModelBase
    {
		private ObservableCollection<BorrowingViewModel> _borrowings;
		public ObservableCollection<BorrowingViewModel> Borrowings
		{
			get
			{
				return _borrowings;
			}
			set
			{
                _borrowings = value;
				OnPropertyChanged(nameof(Borrowings));
			}
		}
		private BorrowingViewModel _selectedBorrowing;
		public BorrowingViewModel SelectedBorrowing
		{
			get
			{
				return _selectedBorrowing;
			}
			set
			{
				_selectedBorrowing = value;
				OnPropertyChanged(nameof(SelectedBorrowing));
			}
		}

		private string _search;
		public string Search
		{
			get
			{
				return _search;
			}
			set
			{
				_search = value;
				OnPropertyChanged(nameof(Search));
			}
		}

		public ICommand TotalBookDamageCommand { get; }
		public ICommand BookDamageCommand { get; }
		public ICommand NoDamageCommand { get; }
		public ICommand CloseCommand { get; }
		private IReturnBookService _returnBookService;
		private IBorrowingService _borrowingService;
		private IBookService _bookService;
		private int _memberId;
        public MemberFinishBorrowingDialogViewModel(Window window, IBookService bookService, IBorrowingService borrowingService, IReturnBookService returnBookService, int memberId)
        {
			_memberId = memberId;
			_returnBookService = returnBookService;
			_borrowingService = borrowingService;
			_bookService = bookService;
			Borrowings = new ObservableCollection<BorrowingViewModel>();
			LoadBorrowings();
			TotalBookDamageCommand = new RelayCommand(TotalBookDamage, CanExecute);
			BookDamageCommand = new RelayCommand(BookDamage, CanExecute);
			NoDamageCommand = new RelayCommand(NoDamage, CanExecute);
			CloseCommand = new CloseCommand(window);
        }

		private void LoadBorrowings()
		{
			Borrowings.Clear();
			foreach(var borrowing in _borrowingService.GetAllNotFinished(_memberId))
			{
				var bookTitle = _bookService.GetBookTitleByCopy(borrowing.BookCopyInventoryNumber);
				var bookCopy = _bookService.GetBookCopy(borrowing.BookCopyInventoryNumber, bookTitle);
				Borrowings.Add(new BorrowingViewModel(borrowing, bookCopy, bookTitle));
			}
		}
		private bool CanExecute()
		{
			return SelectedBorrowing is not null;
		}

		private void TotalBookDamage()
		{
			var price = _returnBookService.ReturnWithTotalDamage(SelectedBorrowing.Borrowing, SelectedBorrowing.BookCopy, SelectedBorrowing.BookTitle.Id, _memberId);
			MessageBox.Show("Kazna za totalno ostecenje je :" + price);
			PayForLate();
        }

		private void BookDamage()
		{
			var price = (SelectedBorrowing.BookCopy.PurchasePrice / 2);
            _returnBookService.ReturnWithDamage(SelectedBorrowing.Borrowing, SelectedBorrowing.BookCopy, SelectedBorrowing.BookTitle.Id, price, _memberId);
			MessageBox.Show("Kazna za totalno ostecenje je: " + price);
			PayForLate();
		}

		private void PayForLate()
		{
            var price = _returnBookService.PayForLate(SelectedBorrowing.Borrowing, _memberId);
            if (price != 0)
            {
                MessageBox.Show("Kazna za kasnjenje je: " + price);
            }
            LoadBorrowings();
        }

		private void NoDamage()
		{
			_returnBookService.ReturnWithNoDamage(SelectedBorrowing.Borrowing, SelectedBorrowing.BookCopy, SelectedBorrowing.BookTitle.Id);
			MessageBox.Show("Uspesno ste vratili knjigu.");
			PayForLate();
        }
    }
}
