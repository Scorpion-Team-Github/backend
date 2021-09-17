using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface IBillService:ICrudService<Bill>
    {
        IEnumerable<Bill> GetBillsByPaymentCategory(int PaymentCategoryId);
        IEnumerable<Bill> GetBillsByBuilding(int BuildingId);
        IEnumerable<Bill> GetBillsByCondominium(int CondominiumId);
    }
}