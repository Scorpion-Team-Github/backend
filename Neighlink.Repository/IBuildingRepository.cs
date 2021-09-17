using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface IBuildingRepository:ICrudRepository<Building>
    {
         IEnumerable<Building> GetBuildingsByCondominium(int condominiumId);
    }
}