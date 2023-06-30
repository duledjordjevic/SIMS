using Biblioteka.Enums;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class UserAccount : ISerializable
    {
        public int Id { get ; set ; }
        public string Email { get; set ; }
        public string Password { get; set ; }
        public AccountType AccountType { get; set ; }
        public UserAccount() { }
        public UserAccount(string email, string password, AccountType accountType)
        {
            AccountType = accountType ;
            Email = email;
            Password = password;
        }

    }
}
