using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ViewModel.Structures
{
    public class BookViewModel : ViewModelBase
    {
        public BookCopy BookCopy { get; set; }
		public string Title { get; }
        public string InventoryNumber { get; }
        public string ISBN { get; }

        public BookViewModel() { }

        public BookViewModel(BookCopy bookCopy, string title, string inventoryNumber, string iSBN)
        {
            BookCopy = bookCopy;
            Title = title;
            InventoryNumber = inventoryNumber;
            ISBN = iSBN;
        }
    }
}
