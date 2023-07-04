using Biblioteka.Command;
using Biblioteka.Service;
using Biblioteka.ViewModel.Structures;
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

        public MemberFinishBorrowingDialogViewModel(Window window)
        {
			CloseCommand = new CloseCommand(window);
        }

		private bool CanExecute()
		{
			return SelectedBorrowing is not null;
		}

		private void TotalBookDamage()
		{

		}
    }
}
