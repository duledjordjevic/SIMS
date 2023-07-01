using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service.Interface
{
    public interface IUserAccountService
    {
        void Add(UserAccount account);
        UserAccount Get(int id);
        Dictionary<int, UserAccount> GetAll();
        void Remove(int id);
        void Update(UserAccount account);
        bool CheckUserExistanceEmail(string email);
        bool IsEmailValid(string email);
    }
}