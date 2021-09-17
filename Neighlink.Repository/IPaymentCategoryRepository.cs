using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface IPaymentCategoryRepository:ICrudRepository<PaymentCategory>
    {
         IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId);
    }
}