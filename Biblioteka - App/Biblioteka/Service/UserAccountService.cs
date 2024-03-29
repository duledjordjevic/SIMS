﻿using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Repository.Core;
using Biblioteka.Repository.Interface;
using Biblioteka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class UserAccountService : IUserAccountService
    {
        private IUserAccountRepository _repo;
        public UserAccountService(IUserAccountRepository repo)
        {
            _repo = repo;
        }

        public void Add(UserAccount account)
        {
            _repo.Add(account);
        }

        public void Update(UserAccount account)
        {
            _repo.Update(account);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public UserAccount Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, UserAccount> GetAll()
        {
            return _repo.GetAll();
        }

        public bool CheckUserExistanceEmail(string email)
        {
            return GetAll().Values.Any(account => email == account.Email);
        }

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        }

        public UserAccount GetByEmail(string email)
        {
            return GetAll().Values.First(account => email == account.Email);
        }
        public void Add(string email, string password, AccountType accountType)
        {
            _repo.Add(new UserAccount(email, password, accountType));
        }
    }
}
