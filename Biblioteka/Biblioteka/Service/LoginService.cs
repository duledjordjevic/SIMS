﻿using Biblioteka.Repository.Interface;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Login(string username, string Password, MainViewModel mainViewModel)
        {
            
        }

        //private bool IsValidPassword(Person? user, string password)
        //{
        //    return user is not null && user.Password == password;
        //}
    }
}