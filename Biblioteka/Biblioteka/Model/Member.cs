using Biblioteka.Enums;
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
        public string Jmbg { get; set; }
        public string Telephone { get; set; }
        public MembershipType MembershipType { get; set; }
        public int UserAccountId { get; set; }
        public MemberCard MemberCard { get; set; }
        public Address Adress { get; set; }
        public Member() { }
        public Member(string name, string lastName, string jmbg, string telephone, MemberCard memberCard, Address adress, MembershipType membershipType, int userAccountId)
        {
            Name = name;
            LastName = lastName;
            Jmbg = jmbg;
            Telephone = telephone;
            MemberCard = memberCard;
            Adress = adress;
            MembershipType = membershipType;
            UserAccountId = userAccountId;
        }
    }
}
