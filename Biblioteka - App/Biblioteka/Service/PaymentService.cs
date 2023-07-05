using Biblioteka.Model;
using Biblioteka.Repository;
using Biblioteka.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _repo;
        public PaymentService(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public void Add(Payment payment)
        {
            _repo.Add(payment);
        }

        public void Update(Payment payment)
        {
            _repo.Update(payment);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Payment Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Payment> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
