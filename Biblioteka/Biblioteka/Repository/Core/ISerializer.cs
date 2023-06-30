using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository.Core
{
    public interface ISerializer<T> where T : ISerializable, new()
    {
        Dictionary<int, T> Load();
        void Save(Dictionary<int, T> objects);
    }
}
