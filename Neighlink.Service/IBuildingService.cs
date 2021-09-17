using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface IBuildingService:ICrudService<Building>
    {
         IEnumerable<Building> GetBuildingsByCondominium(int condominiumId);
    }
}