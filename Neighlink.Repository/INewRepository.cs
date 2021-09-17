using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface INewRepository:ICrudRepository<News>
    {
         IEnumerable<News> GetNewsByCondominium(int condominiumId);
    }
}