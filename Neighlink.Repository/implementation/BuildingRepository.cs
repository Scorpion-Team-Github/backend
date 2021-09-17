using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class BuildingRepository : CrudRepository<Building>, IBuildingRepository
    {
        private ApplicationDbContext _context;
        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
            Init( context );
        }

        public IEnumerable<Building> GetBuildingsByCondominium(int condominiumId)
        {
            return _context.Buildings.Where( x => x.CondominiumId == condominiumId ).AsEnumerable();
        }
    }
}