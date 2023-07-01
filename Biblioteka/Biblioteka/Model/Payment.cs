using Biblioteka.Enums;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Payment : ISerializable
    {
        public int Id { get ; set ; }
        public PaymentType PaymentType { get; set ; }
        public double Amount { get; set ; }
        public DateTime Date;

        public Payment(){}

        public Payment(PaymentType paymentType, double amount, DateTime date)
        {
            PaymentType = paymentType;
            Amount = amount;
            Date = date;
        }
    }
}
