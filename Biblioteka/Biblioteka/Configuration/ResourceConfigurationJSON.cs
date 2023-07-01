using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Configuration
{
    public class ResourceConfigurationJSON<T> : IResourceConfiguration<T>
    {
        private string UserAccountJSON = @"..\..\..\Data\userAccount.json";
        private string MemberJSON = @"..\..\..\Data\member.json";
        private string PaymentJSON = @"..\..\..\Data\payment.json";
        public string GetResourcePath()
        {
            return typeof(T).Name switch
            {
                nameof(UserAccount) => UserAccountJSON,
                nameof(Member) => MemberJSON,
                nameof(Payment) => PaymentJSON,
                _ => string.Empty,
            };
        }
    }
}
