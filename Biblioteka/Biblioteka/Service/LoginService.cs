using Biblioteka.Repository.Interface;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteka.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public LoginService(IUserAccountRepository userAccountRepository) 
        { 
            _userAccountRepository = userAccountRepository; 
            //_mainViewModel = mainViewModel;
        }
        public void Login(string email, string password, MainViewModel mainViewModel)
        {
            foreach(var account in _userAccountRepository.GetAll().Values)
            {
                if (account.Email == email && account.Password == password)
                {
                    if (account.AccountType == Enums.AccountType.ADMIN)
                    {
                        mainViewModel.CurrentViewModel = new AdminViewModel();
                    }
                    else if (account.AccountType == Enums.AccountType.LIBRARIAN)
                    {

                    }
                    else if (account.AccountType == Enums.AccountType.SPECIAL_LIBRARIAN)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Lose uneti podaci");
                }
            }
        }

        //private bool IsValidPassword(Person? user, string password)
        //{
        //    return user is not null && user.Password == password;
        //}
    }
}
