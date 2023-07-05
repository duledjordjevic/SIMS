using Biblioteka.Enums;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class BookTitle : ISerializable
    {
        public int Id { get ; set ; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public BookCoverType BookCoverType { get; set; }    
        public string Format { get; set; }
        public string ISBN { get; set; }
        public string UDK { get; set; } 
        public int PublicationYear { get; set; }
        public List<int> Authors { get; set; }
        public int PublisherId { get; set; }
        public List<BookCopy> BookCopies { get; set; }

        public BookTitle() { }
        public BookTitle(string title, string description, string language, BookCoverType bookCoverType, string format, string iSBN, string uDK, int publicationYear, List<int> authors, int publisherId, List<BookCopy> bookCopies)
        {
            Title = title;
            Description = description;
            Language = language;
            BookCoverType = bookCoverType;
            Format = format;
            ISBN = iSBN;
            UDK = uDK;
            PublicationYear = publicationYear;
            Authors = authors;
            PublisherId = publisherId;
            BookCopies = bookCopies;
        }
    }
}
