using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class CondominiumRepository : CrudRepository<Condominium>, ICondominiumRepository
    {
        private ApplicationDbContext _context;

        public CondominiumRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
    }
}