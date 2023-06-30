using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Member : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Jmbg { get; set; }
        public int Telephone { get; set; }
        public int UserAccountId { get; set; }
        public MemberCard MemberCard { get; set; }
        public Member() { }
        public Member(string name, string lastName, int jmbg, int telephone, MemberCard memberCard)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Telephone = telephone;
            MemberCard = memberCard;
        }
    }
}
