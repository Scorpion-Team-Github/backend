using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class OptionRepository : CrudRepository<Option>, IOptionRepository
    {
        private ApplicationDbContext _context;
        public OptionRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
    }
}