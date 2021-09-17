using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        public PaymentService(ApplicationDbContext context)
        {
            _paymentRepository = new PaymentRepository( context );
        }
        public void Add(Payment entity)
        {
            _paymentRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _paymentRepository.Delete( id );
        }

        public Payment Get(int id)
        {
            return _paymentRepository.GetById( id );
        }

        public IEnumerable<Payment> GetAll()
        {
            return _paymentRepository.GetAll();
        }

        public void Update(Payment entity)
        {
            _paymentRepository.Update( entity );
        }

        public IEnumerable<Payment> GetPaymentsByBill(int billId)
        {
            return _paymentRepository.GetPaymentsByBill( billId );
        }
        public IEnumerable<Payment> GetPaymentsByUser(int userId)
        {
            return _paymentRepository.GetPaymentsByUser( userId );
        }
        public IEnumerable<Payment> GetPaymentsByCondominium(int condominiumId)
        {
            return _paymentRepository.GetPaymentsByCondominium( condominiumId );
        }
    }
}