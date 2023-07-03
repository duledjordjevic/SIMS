using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.ViewModel.Structures;
using Biblioteka.ViewModel.Table;
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
    public class AddingBookTitleDialogViewModel : ViewModelBase
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
		public ObservableCollection<BookCoverType> BookCoverTypes { get; }
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
		private Publisher _selectedPublisher;
		public Publisher SelectedPublisher
		{
			get
			{
				return _selectedPublisher;
			}
			set
			{
				_selectedPublisher = value;
				OnPropertyChanged(nameof(SelectedPublisher));
			}
		}
		private string _publisherName;
		public string PublisherName
        {
			get
			{
				return _publisherName;
			}
			set
			{
				_publisherName = value;
				OnPropertyChanged(nameof(PublisherName));
			}
		}
		private string _publisherHeadOffice;
		public string PublisherHeadOffice
        {
			get
			{
				return _publisherHeadOffice;
			}
			set
			{
				_publisherHeadOffice = value;
				OnPropertyChanged(nameof(PublisherHeadOffice));
			}
		}
		public ICommand AddPublisherCommand { get; }
		public ICommand AddAuthorCommand { get; }
		public ICommand AddBookCommand { get; }
        public ICommand CloseCommand { get; }
		private IBookService _bookService;
		private BookTableViewModel _bookTableViewModel;
        public AddingBookTitleDialogViewModel(Window window,BookTableViewModel bookTableViewModel, IBookService bookService)
        {
			_bookService = bookService;
			_bookTableViewModel = bookTableViewModel;
			Authors = new ObservableCollection<AuthorViewModel>();
			Publishers = new ObservableCollection<Publisher>();
			LoadAuthors();
			LoadPublishers();
            var bookCoverTypes = Enum.GetValues(typeof(BookCoverType)).Cast<BookCoverType>().ToList();
            BookCoverTypes = new ObservableCollection<BookCoverType>(bookCoverTypes);
            AddAuthorCommand = new RelayCommand(AddAuthor, CanAddAuthor);
			AddPublisherCommand = new RelayCommand(AddPublisher, CanAddPublisher);
			AddBookCommand = new RelayCommand(AddBook, CanAddBook);
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

		public bool CanAddAuthor()
		{
			return (AuthorName is not null) && 
				(AuthorLastName is not null) ;

        }
		public void AddAuthor()
		{
			if(!(_bookService.ExistOfAuthor(AuthorName, AuthorLastName)))
			{
				_bookService.AddAuthor(AuthorName, AuthorLastName);
				MessageBox.Show("Uspesno ste dodali autora.");
				AuthorName = "";
				AuthorLastName = "";
				LoadAuthors();
			}
			else
			{
				MessageBox.Show("Ovaj autor vec postoji");
			}
		}

		public bool CanAddPublisher()
		{
			return (PublisherName is not null) &&
				   (PublisherHeadOffice is not null);
		}
		public void AddPublisher()
		{
			if (!(_bookService.ExistOfPublisher(PublisherName, PublisherHeadOffice)))
			{
				_bookService.AddPublisher(PublisherName, PublisherHeadOffice);
				MessageBox.Show("Uspesno ste dodali izdavaca.");
				PublisherName = "";
				PublisherHeadOffice = "";
				LoadPublishers();
			}
			else
			{
				MessageBox.Show("Ovaj izdavac vec postoji");
			}
        }

		public bool CanAddBook()
		{
			return (Title is not null) &&
					(Language is not null) &&
					(Format is not null) &&
					(Description is not null) &&
					(ISBN is not null) &&
					(UDK is not null) &&
					(PublicationYear != 0);
		}
		public void AddBook()
		{
			if(!(_bookService.ExistOfBook(ISBN, UDK)))
			{
				var selectedAuthors = new List<int>();
				foreach(var author in Authors)
				{
					if (author.IsSelected) selectedAuthors.Add(author.Author.Id);
				}
				if (selectedAuthors.Count > 0)
				{
					_bookService.AddBook(Title, Description, Language, SelectedBookCoverType, Format, ISBN, UDK, PublicationYear, selectedAuthors, SelectedPublisher.Id, null);
					MessageBox.Show("Uspesno ste dodali knjigu.");
					_bookTableViewModel.LoadBooks();
                    CloseCommand.Execute(this);
				}
				else
				{
					MessageBox.Show("Morate odabrati bar jednog autora za knjigu");
				}
			}
			else
			{
				MessageBox.Show("Knjiga sa ovim ISBN i UDK brojem vec postoji");
			}
		}

    }
}
