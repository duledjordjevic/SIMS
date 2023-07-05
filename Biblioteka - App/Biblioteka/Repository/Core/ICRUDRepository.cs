using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository.Core
{
    public interface ICRUDRepository<T> where T : ISerializable, new()
    {
        void Add(T obj);
        Dictionary<int, T> GetAll();
        T Get(int id);
        void Remove(int id);
        void Update(T obj);
        void Save(Dictionary<int, T> objects);
    }
}
