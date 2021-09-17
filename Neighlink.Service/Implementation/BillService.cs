using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class BillService : IBillService
    {
        private IBillRepository _billRepository;

        public BillService(ApplicationDbContext context)
        {
            _billRepository = new BillRepository( context );
        }

        public void Add(Bill entity)
        {
            _billRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _billRepository.Delete( id );
        }

        public Bill Get(int id)
        {
            return _billRepository.GetById( id );
        }

        public IEnumerable<Bill> GetAll()
        {
            return _billRepository.GetAll();
        }

        public void Update(Bill entity)
        {
            _billRepository.Update( entity );
        }

        public IEnumerable<Bill> GetBillsByBuilding(int _buildingId)
        {
            return _billRepository.GetBillsByBuilding( _buildingId );
        }

        public IEnumerable<Bill> GetBillsByCondominium(int condominiumId)
        {
            return _billRepository.GetBillsByCondominium( condominiumId );
        }

        public IEnumerable<Bill> GetBillsByPaymentCategory(int paymentCategoryId)
        {
            return _billRepository.GetBillsByPaymentCategory( paymentCategoryId );
        }
    }
}