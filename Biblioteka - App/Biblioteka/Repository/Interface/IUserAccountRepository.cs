using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository.Interface
{
    public interface IUserAccountRepository
    {
        void Add(UserAccount account);
        UserAccount Get(int id);
        Dictionary<int, UserAccount> GetAll();
        void Remove(int id);
        void Update(UserAccount account);
    }
}