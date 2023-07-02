using Biblioteka.Model;
using Biblioteka.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class BookService
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


        public void AddBook()
        {

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
    }
}
