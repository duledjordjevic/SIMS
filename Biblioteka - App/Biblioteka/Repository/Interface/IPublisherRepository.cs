using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IPublisherRepository
    {
        void Add(Publisher publisher);
        Publisher Get(int id);
        Dictionary<int, Publisher> GetAll();
        void Remove(int id);
        void Update(Publisher publisher);
    }
}