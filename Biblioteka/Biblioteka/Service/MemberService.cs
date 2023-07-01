using Biblioteka.Model;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Repository;
using Biblioteka.Enums;

namespace Biblioteka.Service
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _repo;
        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        private void Add(Member member)
        {
            _repo.Add(member);
        }
        public void Add(string name, string lastName, string jmbg, string telephone, MembershipType membershipType, int userAccountId, string street, string city, int postalCode)
        {
            DateOnly expiryDate = new DateOnly(DateTime.Now.AddYears(1).Year, DateTime.Now.AddYears(1).Month, DateTime.Now.AddYears(1).Day);
            var memberCard = new MemberCard(expiryDate);
            var address = new Address(street, city, postalCode);
            _repo.Add(new Member(name, lastName, jmbg, telephone, memberCard, address, membershipType));
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

        public Member? GetByAccountId(int id)
        {
            return GetAll().Values.FirstOrDefault(member => member.UserAccountId == id);
        }

    }
}
