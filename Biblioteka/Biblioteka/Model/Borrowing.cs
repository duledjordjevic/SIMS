using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Borrowing : ISerializable
    {
        public int Id { get ; set ; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsProlonged { get; set; }
        public bool IsFinished { get; set; }
        public int MemberId { get; set; }
        public string BookCopyInventoryNumber { get; set; }

        public Borrowing() {}

        public Borrowing(DateTime start, DateTime end, int memberId, string bookCopyInventoryNumber)
        {
            Start = start;
            End = end;
            MemberId = memberId;
            BookCopyInventoryNumber = bookCopyInventoryNumber;
        }
    }
}
