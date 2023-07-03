using Biblioteka.Command;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.ViewModel.Structures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Table
{
    public class BorrowingTableViewModel : ViewModelBase
    {
		private ObservableCollection<Member> _members;
		public ObservableCollection<Member> Members
		{
			get
			{
				return _members;
			}
			set
			{
                _members = value;
				OnPropertyChanged(nameof(Members));
			}
		}
		private Member _selectedMember;
		public Member SelectedMember
		{
			get
			{
				return _selectedMember;
			}
			set
			{
				_selectedMember = value;
				OnPropertyChanged(nameof(SelectedMember));
			}
		}
		private ObservableCollection<BookViewModel> _books;
		public ObservableCollection<BookViewModel> Books
		{
			get
			{
				return _books;
			}
			set
			{
				_books = value;
				OnPropertyChanged(nameof(Books));
			}
		}
		private BookViewModel _selectedBook;
		public BookViewModel SelectedBook
		{
			get
			{
				return _selectedBook;
			}
			set
			{
				_selectedBook = value;
				OnPropertyChanged(nameof(SelectedBook));
			}
		}
		private string _searchMembers;
		public string SearchMembers
		{
			get
			{
				return _searchMembers;
			}
			set
			{
				_searchMembers = value;
				OnPropertyChanged(nameof(SearchMembers));
			}
		}
		private string _searchBooks;
		public string SearchBooks
		{
			get
			{
				return _searchBooks;
			}
			set
			{
				_searchBooks = value;
				OnPropertyChanged(nameof(SearchBooks));
			}
		}

		private IBookService _bookService;
		private IMemberService _memberService;
		public ICommand AddBorrowingCommand { get; }
        public ICommand CloseCommand { get; }
		public BorrowingTableViewModel(Window window, IBookService bookService, IMemberService memberService)
		{
			_bookService = bookService;
			_memberService = memberService;
			Members = new ObservableCollection<Member>();
			Books = new ObservableCollection<BookViewModel>();
			LoadMembers();
			LoadBooks();
			AddBorrowingCommand = new RelayCommand(AddBorrowing, CanAddBorrowing);
			CloseCommand = new CloseCommand(window);
            PropertyChanged += OnPropertyChanged;
        }

		public void LoadMembers()
		{
			Members.Clear();
			foreach(var member in _memberService.GetAll().Values)
			{
				Members.Add(member);
			}
		}

		public bool CanAddBorrowing()
		{
			return (SelectedMember is not null) && (SelectedBook is not null);
		}
		public void AddBorrowing()
		{

		}

		public void LoadBooks()
		{
			Books.Clear();
			var bookTitles = _bookService.GetAllBookTitles().Values;
			foreach(var bookTitle in bookTitles)
			{
				if (bookTitle.BookCopies is not null)
				{
					foreach(var bookCopy in bookTitle.BookCopies) 
					{
						if (bookCopy.BookCopyStatus == Enums.BookCopyStatus.AVAILABLE)
						{
							Books.Add(new BookViewModel(bookCopy, bookTitle.Title, bookCopy.InventoryNumber, bookTitle.ISBN));
						}
					}
				}
			}
		}

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchMembers))
            {
                if (!string.IsNullOrEmpty(SearchMembers))
                {
                    var filteredMembers = Members.Where(member => member.Name.ToLower().Contains(SearchMembers.ToLower())
                    || member.LastName.ToLower().Contains(SearchMembers.ToLower())
                    || member.Jmbg.ToLower().Contains(SearchMembers.ToLower())).ToList();
                    Members.Clear();
                    foreach (var member in filteredMembers)
                    {
                        Members.Add(member);
                    }
                }
                else
                {
					LoadMembers();
                }
            }else if (e.PropertyName == nameof(SearchBooks)){
                if (!string.IsNullOrEmpty(SearchBooks))
                {
                    var filteredBooks = Books.Where(book => book.Title.ToLower().Contains(SearchBooks.ToLower())
                    || book.InventoryNumber.ToLower().Contains(SearchBooks.ToLower())
                    || book.ISBN.ToLower().Contains(SearchBooks.ToLower())).ToList();
                    Books.Clear();
                    foreach (var book in filteredBooks)
                    {
                        Books.Add(book);
                    }
                }
                else
                {
                    LoadBooks();
                }
            }
        }


    }
}
