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
        private readonly IUserAccountService _userAccountService;
        private readonly IMemberService _memberService;
        public LoginService(IUserAccountService userAccountService, IMemberService memberService) 
        {
            _userAccountService = userAccountService;
            _memberService = memberService;
        }
        public void Login(string email, string password, MainViewModel mainViewModel)
        {
            foreach(var account in _userAccountService.GetAll().Values)
            {
                if (account.Email == email && account.Password == password)
                {
                    if (account.AccountType == Enums.AccountType.ADMIN)
                    {
                        mainViewModel.CurrentViewModel = new AdminViewModel(_userAccountService);
                    }
                    else if (account.AccountType == Enums.AccountType.LIBRARIAN)
                    {
                        mainViewModel.CurrentViewModel = new LibrarianViewModel();
                    }
                    else if (account.AccountType == Enums.AccountType.SPECIAL_LIBRARIAN)
                    {
                        mainViewModel.CurrentViewModel = new SpecialLibrarianViewModel();
                    }
                    else
                    {
                        mainViewModel.CurrentViewModel = new MemberViewModel();
                        MessageBox.Show(_memberService.GetByAccountId(account.Id).Adress.City);
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
