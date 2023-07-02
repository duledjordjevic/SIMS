using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Author : ISerializable
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<int> BookTitles { get; set; }
        public Author(){}
        public Author(string name, string lastName, List<int> bookTitles)
        {
            Name = name;
            LastName = lastName;
            BookTitles = bookTitles;
        }
    }
}
