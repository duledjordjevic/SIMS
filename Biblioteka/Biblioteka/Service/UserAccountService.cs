using Biblioteka.Model;
using Biblioteka.Repository.Core;
using Biblioteka.Repository.Interface;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class UserAccountService : IUserAccountService
    {
        private IUserAccountRepository _repo;
        public UserAccountService(IUserAccountRepository repo)
        {
            _repo = repo;
        }

        public void Add(UserAccount account)
        {
            _repo.Add(account);
        }

        public void Update(UserAccount account)
        {
            _repo.Update(account);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public UserAccount Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, UserAccount> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
