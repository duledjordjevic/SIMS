using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ViewModel.Structures
{
    public class BorrowingViewModel : ViewModelBase
    {
        public Borrowing Borrowing { get; set; }
        public BookCopy BookCopy { get; set; }
        public BookTitle BookTitle { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsProlonged { get; set; }
        public string Title { get; set; }
        public BorrowingViewModel(Borrowing borrowing, BookCopy bookCopy, BookTitle bookTitle) 
        {
            BookTitle = bookTitle;
            Borrowing = borrowing;
            BookCopy = bookCopy;
            Start = Borrowing.Start;
            End = Borrowing.End;
            IsProlonged = Borrowing.IsProlonged;
            Title = bookTitle.Title;
        }
    }
}
