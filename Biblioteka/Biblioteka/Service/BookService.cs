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


    }
}
