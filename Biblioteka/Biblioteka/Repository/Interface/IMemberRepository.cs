using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IMemberRepository
    {
        void Add(Member member);
        Member Get(int id);
        Dictionary<int, Member> GetAll();
        void Remove(int id);
        void Update(Member member);
    }
}