using System.Collections.Generic;
using Neighlink.Entity.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class PollRepository : CrudRepository<Poll>, IPollRepository
    {
        private ApplicationDbContext _context;

        public PollRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
    }
}