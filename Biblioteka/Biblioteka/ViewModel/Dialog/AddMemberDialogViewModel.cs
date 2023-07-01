using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Biblioteka.ViewModel.Dialog
{
    public class AddMemberDialogViewModel : ViewModelBase
    {
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		private string _lastName;
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}
		private string _jmbg;
		public string Jmbg
		{
			get
			{
				return _jmbg;
			}
			set
			{
				_jmbg = value;
				OnPropertyChanged(nameof(Jmbg));
			}
		}
		private string _telephone;
		public string Telephone
		{
			get
			{
				return _telephone;
			}
			set
			{
				_telephone = value;
				OnPropertyChanged(nameof(Telephone));
			}
		}
		private string _email;
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}
		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}
        public ObservableCollection<MembershipType> MembershipTypes { get; set; }
        private MembershipType _selectedMembershipType;
		public MembershipType SelectedMembershipType
		{
			get
			{
				return _selectedMembershipType;
			}
			set
			{
                _selectedMembershipType = value;
				OnPropertyChanged(nameof(MembershipType));
			}
		}

		public CommandBase AddMemberCommand { get; }

        public ICommand CloseCommand { get; }
		public AddMemberDialogViewModel(Window window, IUserAccountService userAccountService, IMemberService memberService)
		{
            var membershipTypes = Enum.GetValues(typeof(MembershipType)).Cast<MembershipType>().ToList();
            MembershipTypes = new ObservableCollection<MembershipType>(membershipTypes);
            CloseCommand = new CloseCommand(window);
		}

	}
}
