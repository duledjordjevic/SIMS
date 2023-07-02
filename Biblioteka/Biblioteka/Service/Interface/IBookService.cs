using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service
{
    public interface IBookService
    {
        void AddAuthor(string name, string lastName);
        void AddBook();
        void AddPublisher(string name, string headOffice);
        bool ExistOfAuthor(string name, string lastName);
        bool ExistOfPublisher(string name, string headOffice);
        Dictionary<int, Author> GetAllAuthors();
        Dictionary<int, Publisher> GetAllPublishers();
    }
}