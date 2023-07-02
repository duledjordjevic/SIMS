using Biblioteka.Enums;
using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service
{
    public interface IBookService
    {
        void AddAuthor(string name, string lastName);
        void AddBook(string title, string description, string language, BookCoverType bookCoverType, string format, string isbn, string udk, int publicationYear, List<int> authors, int publisherId, List<BookCopy> bookCopies);
        void AddPublisher(string name, string headOffice);
        bool ExistOfAuthor(string name, string lastName);
        bool ExistOfBook(string isbn, string udk);
        bool ExistOfPublisher(string name, string headOffice);
        Dictionary<int, Author> GetAllAuthors();
        Dictionary<int, Publisher> GetAllPublishers();
    }
}