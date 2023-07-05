using Biblioteka.Command;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
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

        public ICommand SubmitCommand { get; }

        private readonly MainViewModel _mainViewModel;
        public MainViewModel MainViewModel => _mainViewModel;
        public LoginViewModel(MainViewModel mainViewModel, ILoginService loginService) 
        {
            _mainViewModel = mainViewModel;
            SubmitCommand = new LoginCommand(this, mainViewModel, loginService);

        }
    }
}
