
using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using System.Linq;

namespace Neighlink.Repository.implementation
{
    public class NewRepository : CrudRepository<News>, INewRepository
    {
        private ApplicationDbContext _context;
        public NewRepository(ApplicationDbContext context)
        {
            Init( context );
            _context = context;
        }
        public IEnumerable<News> GetNewsByCondominium(int condominiumId)
        {
            return _context.News
            .Where( x => x.CondominiumId == condominiumId )
            .AsEnumerable();
        }
    }
}