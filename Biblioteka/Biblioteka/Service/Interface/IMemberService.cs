using Biblioteka.Enums;
using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Service
{
    public interface IMemberService
    {
        void Add(string name, string lastName, string jmbg, string telephone, MembershipType membershipType, int userAccountId, string street, string city, int postalCode);
        Member Get(int id);
        Dictionary<int, Member> GetAll();
        void Remove(int id);
        void Update(Member member);
        Member? GetByAccountId(int id);
    }
}