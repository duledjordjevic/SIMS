using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.ViewModel.Structures
{
    public class AuthorViewModel : ViewModelBase
    {
        public Author Author;
        public string Name { get; }
        public string LastName { get; }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public AuthorViewModel(Author author) 
        {
            Author = author;
            Name = author.Name;
            LastName = author.LastName;
            IsSelected = false;
        }
    }
}
