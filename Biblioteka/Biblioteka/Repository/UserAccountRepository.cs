using Biblioteka.Model;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private ICRUDRepository<UserAccount> _repo;
        public UserAccountRepository(ICRUDRepository<UserAccount> repo)
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
