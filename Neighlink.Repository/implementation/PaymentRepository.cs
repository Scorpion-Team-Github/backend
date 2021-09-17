using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Neighlink.Repository.implementation
{
    public class PaymentRepository : CrudRepository<Payment>, IPaymentRepository
    {
        private ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }

        public IEnumerable<Payment> GetPaymentsByBill(int billId)
        {
            return _context.Payments
                .Where( x => x.BillId == billId )
                .AsEnumerable();
        }

        public IEnumerable<Payment> GetPaymentsByUser(int userId)
        {
            return _context.Payments
                .Where( x => x.UserId == userId )
                .AsEnumerable();
        }

        public IEnumerable<Payment> GetPaymentsByCondominium(int condominiumId)
        {
            return _context.Users
                .Include( x => x.Payments )
                .Where( y => y.CondominiumId == condominiumId )
                .SelectMany( x => x.Payments )
                .AsEnumerable();
        }

    }
}