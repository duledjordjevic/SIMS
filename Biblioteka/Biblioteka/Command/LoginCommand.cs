using Biblioteka.Service.Interface;
using Biblioteka.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Command
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly MainViewModel _mainViewModel;
        private ILoginService _loginService;
        public LoginCommand(LoginViewModel loginViewModel, MainViewModel mainViewModel, ILoginService loginService)
        {
            _loginViewModel = loginViewModel;
            _mainViewModel = mainViewModel;
            _loginService = loginService;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        public override bool CanExecute(object? parameter)
        {
            return !(String.IsNullOrEmpty(_loginViewModel.UserName)) && !(String.IsNullOrEmpty(_loginViewModel.Password));
        }
        public override void Execute(object? parameter)
        {
            _loginService.Login(_loginViewModel.UserName, _loginViewModel.Password, _mainViewModel);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.UserName) ||
                e.PropertyName == nameof(_loginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
