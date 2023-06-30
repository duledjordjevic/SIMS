using Biblioteka.Model;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private ICRUDRepository<Member> _repo;
        public MemberRepository(ICRUDRepository<Member> repo)
        {
            _repo = repo;
        }

        public void Add(Member member)
        {
            _repo.Add(member);
        }

        public void Update(Member member)
        {
            _repo.Update(member);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Member Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Member> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
