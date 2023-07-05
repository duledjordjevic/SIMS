using Biblioteka.Repository.Core;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Biblioteka.Model
{
    public class Publisher : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeadOffice { get; set; }
        public List<int> BookTitles { get; set; }
        public Publisher() { }
        public Publisher(string name, string headOffice, List<int> bookTitles)        {
            Name = name;
            HeadOffice = headOffice;
            BookTitles = bookTitles;
        }

    }
}