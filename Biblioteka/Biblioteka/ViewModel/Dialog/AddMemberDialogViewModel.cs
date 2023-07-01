using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel.Table;
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
		private string _street;
		public string Street
		{
			get
			{
				return _street;
			}
			set
			{
				_street = value;
				OnPropertyChanged(nameof(Street));
			}
		}
		private string _city;
		public string City
		{
			get
			{
				return _city;
			}
			set
			{
				_city = value;
				OnPropertyChanged(nameof(City));
			}
		}
		private int _postalCode;
		public int PostalCode
		{
			get
			{
				return _postalCode;
			}
			set
			{
				_postalCode = value;
				OnPropertyChanged(nameof(PostalCode));
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
		private MembersTableViewModel _membersTableViewModel;

        public AddMemberDialogViewModel(Window window, MembersTableViewModel membersTableViewModel, IUserAccountService userAccountService, IMemberService memberService, IPaymentService paymentService)
		{
			_membersTableViewModel = membersTableViewModel;
            var membershipTypes = Enum.GetValues(typeof(MembershipType)).Cast<MembershipType>().ToList();
            MembershipTypes = new ObservableCollection<MembershipType>(membershipTypes);
			AddMemberCommand = new AddMemberCommand(this, userAccountService, memberService, paymentService);
            AddMemberCommand.ExcecutionCompleted += AddMemberExecutionCompleted;
            CloseCommand = new CloseCommand(window);
        }

        private void AddMemberExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                _membersTableViewModel.LoadMembers();
                CloseCommand.Execute(this);
			}
			else
			{
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
