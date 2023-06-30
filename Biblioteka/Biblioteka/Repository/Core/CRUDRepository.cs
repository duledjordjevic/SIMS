using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository.Core
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : ISerializable, new()
    {
        private readonly ISerializer<T> _serializer;

        public CRUDRepository(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        public void Save(Dictionary<int, T> objects)
        {
            _serializer.Save(objects);
        }

        public Dictionary<int, T> GetAll()
        {
            return _serializer.Load();
        }

        private int NextId(Dictionary<int, T> objects)
        {
            return (objects?.Any() ?? false) && (objects?.Keys.Max() + 1 ?? 1) > 0 ? objects.Keys.Max() + 1 : 1;
        }

        public T Get(int id)
        {
            var objects = _serializer.Load();

            if (objects.TryGetValue(id, out T obj))
            {
                return obj;
            }
            throw new ArgumentException("Object with the given ID not found.");
        }

        public void Add(T obj)
        {
            var objects = _serializer.Load();

            obj.Id = NextId(objects);
            objects.Add(obj.Id, obj);
            _serializer.Save(objects);
        }

        public void Update(T obj)
        {
            var objects = _serializer.Load();

            objects[obj.Id] = obj;
            _serializer.Save(objects);
        }

        public void Remove(int id)
        {
            var objects = _serializer.Load();

            objects.Remove(id);
            _serializer.Save(objects);
        }


    }
}
