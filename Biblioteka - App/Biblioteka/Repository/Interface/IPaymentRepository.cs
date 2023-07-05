using Biblioteka.Model;
using System.Collections.Generic;

namespace Biblioteka.Repository
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        Payment Get(int id);
        Dictionary<int, Payment> GetAll();
        void Remove(int id);
        void Update(Payment payment);
    }
}