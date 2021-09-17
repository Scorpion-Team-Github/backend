using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class PaymentCategoryService : IPaymentCategoryService
    {
        private IPaymentCategoryRepository _paymentRepository;
        public PaymentCategoryService(ApplicationDbContext context)
        {
            _paymentRepository = new PaymentCategoryRepository( context );
        }
        public void Add(PaymentCategory entity)
        {
            _paymentRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _paymentRepository.Delete( id );
        }

        public PaymentCategory Get(int id)
        {
            return _paymentRepository.GetById( id );
        }

        public IEnumerable<PaymentCategory> GetAll()
        {
            return _paymentRepository.GetAll();
        }

        public void Update(PaymentCategory entity)
        {
            _paymentRepository.Update( entity );
        }

        public IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId)
        {
            return _paymentRepository.GetBuildingsByCondominium( condominiumId );
        }
    }
}