using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Repository
{
    public interface IPaymentRepository:ICrudRepository<Payment>
    {
        IEnumerable<Payment> GetPaymentsByBill(int billId);
        IEnumerable<Payment> GetPaymentsByUser(int userId);
        IEnumerable<Payment> GetPaymentsByCondominium(int condominiumId);
    }
}