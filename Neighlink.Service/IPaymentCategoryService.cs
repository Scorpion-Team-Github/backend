using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Service
{
    public interface IPaymentCategoryService:ICrudService<PaymentCategory>
    {
         IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId);
    }
}