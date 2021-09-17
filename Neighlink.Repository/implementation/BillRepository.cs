using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Neighlink.Repository.implementation
{
    public class BillRepository : CrudRepository<Bill>, IBillRepository
    {
        private ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
        public IEnumerable<Bill> GetBillsByPaymentCategory(int paymentCategoryId)
        {
            return _context.Bills
                .Where( x => x.PaymentCategoryId == paymentCategoryId )
                .AsEnumerable();
        }

        public IEnumerable<Bill> GetBillsByBuilding(int BuildingId)
        {
            return _context.Bills
                .Where( x => x.BuildingId == BuildingId )
                .AsEnumerable();
        }

        public IEnumerable<Bill> GetBillsByCondominium(int CondominiumId)
        {
            return _context.Buildings
                .Include( x => x.Bills )
                .Where( y => y.CondominiumId == CondominiumId )
                .SelectMany( x => x.Bills )
                .AsEnumerable();
        }
    }
}