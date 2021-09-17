using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class PaymentCategoryRepository : CrudRepository<PaymentCategory>, IPaymentCategoryRepository
    {
        private ApplicationDbContext _context;
        public PaymentCategoryRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }

        public IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId)
        {
            return _context.PaymentCategories.Where( x => x.CondominiumId == condominiumId ).AsEnumerable();
        }
    }
}