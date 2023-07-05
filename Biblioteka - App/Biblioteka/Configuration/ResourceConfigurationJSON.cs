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
        private string BookJSON = @"..\..\..\Data\book.json";
        private string AuthorJSON = @"..\..\..\Data\author.json";
        private string PublisherJSON = @"..\..\..\Data\publisher.json";
        private string BorrowingJSON = @"..\..\..\Data\borrowing.json";
        public string GetResourcePath()
        {
            return typeof(T).Name switch
            {
                nameof(UserAccount) => UserAccountJSON,
                nameof(Member) => MemberJSON,
                nameof(Payment) => PaymentJSON,
                nameof(BookTitle) => BookJSON,
                nameof(Author) => AuthorJSON,
                nameof(Publisher) => PublisherJSON,
                nameof(Borrowing) => BorrowingJSON,
                _ => string.Empty,
            };
        }
    }
}
