using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class MemberCard 
    {
        public DateOnly Expiry { get; set; }
        public MemberCard() { }
        public MemberCard(DateOnly expiry)
        {
            Expiry = expiry;
        }
    }
}
