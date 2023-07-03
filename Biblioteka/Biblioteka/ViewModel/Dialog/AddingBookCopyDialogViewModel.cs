using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.ViewModel.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Dialog
{
    public class AddingBookCopyDialogViewModel : ViewModelBase
    {
		private string _inventoryNumber;
		public string InventoryNumber
        {
			get
			{
				return _inventoryNumber;
			}
			set
			{
				_inventoryNumber = value;
				OnPropertyChanged(nameof(InventoryNumber));
			}
		}
		private double _purchasePrice;
		public double PurchasePrice
        {
			get
			{
				return _purchasePrice;
			}
			set
			{
				_purchasePrice = value;
				OnPropertyChanged(nameof(PurchasePrice));
			}
		}

		public ICommand AddBookCopyCommand { get; }
		public ICommand CloseCommand { get; }
		private IBookService _bookService;
		private int _bookTitleId;
		private BookCopiesTableViewModel _bookCopiesTableViewModel;
        public AddingBookCopyDialogViewModel(Window window, BookCopiesTableViewModel bookCopiesTableViewModel, IBookService bookService, int bookTitleId)
        {
            _bookService = bookService;
			_bookTitleId = bookTitleId;
			_bookCopiesTableViewModel = bookCopiesTableViewModel;
			AddBookCopyCommand = new RelayCommand(AddBookCopy, CanAddBookCopy);
			CloseCommand = new CloseCommand(window);
        }

		public bool CanAddBookCopy()
		{
			return (InventoryNumber is not null) && (PurchasePrice != 0 );
		}

		public void AddBookCopy()
		{
			if(!_bookService.ExistOfBookCopy(InventoryNumber, _bookTitleId))
			{
				_bookService.AddBookCopy(InventoryNumber, PurchasePrice, _bookTitleId);
				MessageBox.Show("Uspesno ste dodali novi primerak");
                _bookCopiesTableViewModel.LoadBookCopies();
                CloseCommand.Execute(this);
			}
			else
			{
				MessageBox.Show("Primerak sa ovim inventarnim brojem vec postoji.");
			}
		}
    }
}
