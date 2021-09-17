using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class PlanRepository : CrudRepository<Plan>, IPlanRepository
    {
        private ApplicationDbContext _context;

        public PlanRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
    }
}