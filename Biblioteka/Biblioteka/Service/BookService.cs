using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class BookService : IBookService
    {
        private IBookTitleRepository _bookTitleRepository;
        private IAuthorRepository _authorRepository;
        private IPublisherRepository _publisherRepository;

        public BookService(IBookTitleRepository bookTitleRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookTitleRepository = bookTitleRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }


        public void AddBook(string title, string description, string language, BookCoverType bookCoverType, string format, string isbn, string udk, int publicationYear, List<int> authors, int publisherId, List<BookCopy> bookCopies)
        {
            _bookTitleRepository.Add(new BookTitle(title, description, language, bookCoverType, format, isbn, udk, publicationYear, authors, publisherId, bookCopies));
        }

        public void AddAuthor(string name, string lastName)
        {
            _authorRepository.Add(new Author(name, lastName, null));
        }

        public bool ExistOfAuthor(string name, string lastName)
        {
            return _authorRepository.GetAll().Values.Any(author => author.Name == name && author.LastName == lastName);
        }

        public void AddPublisher(string name, string headOffice)
        {
            _publisherRepository.Add(new Publisher(name, headOffice, null));
        }

        public bool ExistOfPublisher(string name, string headOffice)
        {
            return _publisherRepository.GetAll().Values.Any(publisher => publisher.Name == name && publisher.HeadOffice == headOffice);
        }

        public Dictionary<int, Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Dictionary<int, Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }

        public bool ExistOfBook(string isbn, string udk)
        {
            return _bookTitleRepository.GetAll().Values.Any(book => book.ISBN == isbn && book.UDK == udk);
        }

        public Dictionary<int, BookTitle> GetAllBookTitles()
        {
            return _bookTitleRepository.GetAll();
        }

        public List<BookCopy> GetAllBookCopies(int bookTitleId)
        {
            return _bookTitleRepository.GetAll().Values.First(bookTitle => bookTitle.Id == bookTitleId).BookCopies;
        }

        public void AddBookCopy(string inventoryNumber, double purchasePrice, int bookTitleId)
        {
            var bookCopy = new BookCopy(inventoryNumber, purchasePrice, BookCopyStatus.AVAILABLE);
            var bookTitle = _bookTitleRepository.Get(bookTitleId);

            if (bookTitle.BookCopies is  null) bookTitle.BookCopies = new List<BookCopy>();

            bookTitle.BookCopies.Add(bookCopy);
            _bookTitleRepository.Update(bookTitle);
        }

        public bool ExistOfBookCopy(string inventoryNumber)
        {
            foreach(var bookTitle in _bookTitleRepository.GetAll().Values)
            {
                if(bookTitle.BookCopies is not null)
                {
                    return bookTitle.BookCopies.Any(copy => copy.InventoryNumber == inventoryNumber);
                }
            }
            return false;
        }


        public void UpdateBookCopy(BookCopy bookCopy, int bookTitleId)
        {
            var bookTitle = _bookTitleRepository.Get(bookTitleId);
            int x = 0;
            for (int i = 0; i < bookTitle.BookCopies.Count; i++)
            {
                if (bookTitle.BookCopies[i].InventoryNumber == bookCopy.InventoryNumber)
                {
                    x = i; break;
                }
            }
            bookTitle.BookCopies[x] = bookCopy;
            _bookTitleRepository.Update(bookTitle);
        }

        public BookTitle? GetBookTitleByCopy(string inventoryNumber)
        {
            foreach(var bookTitle in _bookTitleRepository.GetAll().Values)
            {
                if (bookTitle.BookCopies is not null)
                {
                    foreach(var copy in bookTitle.BookCopies)
                    {
                        if (copy.InventoryNumber == inventoryNumber) return bookTitle;
                    }
                }
            }
            return null;
        }

        public BookCopy? GetBookCopy(string inventoryNumber, BookTitle bookTitle) 
        {
            if (bookTitle.BookCopies is not null)
            {
                foreach (var copy in bookTitle.BookCopies)
                {
                    if (copy.InventoryNumber == inventoryNumber) return copy;
                }
            }
            return null;
        }
    }
}
