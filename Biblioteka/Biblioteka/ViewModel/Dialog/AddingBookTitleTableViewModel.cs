using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Model;
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

namespace Biblioteka.ViewModel.Dialog
{
    public class AddingBookTitleTableViewModel : ViewModelBase
    {
		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

        private string _language;
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }
		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}
		private string _format;
		public string Format
		{
			get
			{
				return _format;
			}
			set
			{
				_format = value;
				OnPropertyChanged(nameof(Format));
			}
		}
		public ObservableCollection<BookCoverType> BookCoverTypes;
        private BookCoverType _selectedBookCoverType;
		public BookCoverType SelectedBookCoverType
        {
			get
			{
				return _selectedBookCoverType;
			}
			set
			{
				_selectedBookCoverType = value;
				OnPropertyChanged(nameof(SelectedBookCoverType));
			}
		}
		private string _isbn;
		public string ISBN
		{
			get
			{
				return _isbn;
			}
			set
			{
				_isbn = value;
				OnPropertyChanged(nameof(ISBN));
			}
		}
		private string _udk;
		public string UDK
		{
			get
			{
				return _udk;
			}
			set
			{
				_udk = value;
				OnPropertyChanged(nameof(UDK));
			}
		}
		private int _publicationYear;
		public int PublicationYear
        {
			get
			{
				return _publicationYear;
			}
			set
			{
				_publicationYear = value;
				OnPropertyChanged(nameof(PublicationYear));
			}
		}
		private string _authorName;
		public string AuthorName
        {
			get
			{
				return _authorName;
			}
			set
			{
				_authorName = value;
				OnPropertyChanged(nameof(AuthorName));
			}
		}
		private string _authorLastName;
		public string AuthorLastName
        {
			get
			{
				return _authorLastName;
			}
			set
			{
				_authorLastName = value;
				OnPropertyChanged(nameof(AuthorLastName));
			}
		}
		private ObservableCollection<AuthorViewModel> _authors;
		public ObservableCollection<AuthorViewModel> Authors
		{
			get
			{
				return _authors;
			}
			set
			{
                _authors = value;
				OnPropertyChanged(nameof(Authors));
			}
		}
		private ObservableCollection<Publisher> _publishers;
		public ObservableCollection<Publisher> Publishers
		{
			get
			{
				return _publishers;
			}
			set
			{
                _publishers = value;
				OnPropertyChanged(nameof(Publishers));
			}
		}

		public ICommand AddAuthorCommand { get; }
		public ICommand AddBookCommand { get; }
        public ICommand CloseCommand { get; }
		private IBookService _bookService;
        public AddingBookTitleTableViewModel(Window window, IBookService bookService)
        {
			_bookService = bookService;
			Authors = new ObservableCollection<AuthorViewModel>();
			Publishers = new ObservableCollection<Publisher>();
			LoadAuthors();
			LoadPublishers();
			CloseCommand = new CloseCommand(window);
        }

		public void LoadAuthors()
		{
			Authors.Clear();
			foreach(var author in _bookService.GetAllAuthors().Values)
			{
				Authors.Add(new AuthorViewModel(author));
			}
		}

		public void LoadPublishers()
		{
            Publishers.Clear();
            foreach (var publisher in _bookService.GetAllPublishers().Values)
            {
                Publishers.Add(publisher);
            }
        }
    }
}
