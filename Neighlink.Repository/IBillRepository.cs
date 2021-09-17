using Neighlink.Entity;
using System.Collections.Generic;
namespace Neighlink.Repository
{
    public interface IBillRepository :ICrudRepository<Bill>
    {
        IEnumerable<Bill> GetBillsByPaymentCategory(int PaymentCategoryId);
        IEnumerable<Bill> GetBillsByBuilding(int BuildingId);
        IEnumerable<Bill> GetBillsByCondominium(int CondominiumId);
    }
}