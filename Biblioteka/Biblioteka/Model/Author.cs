using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Author(){}
        public Author(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
