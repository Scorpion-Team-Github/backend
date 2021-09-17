using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface INewService:ICrudService<News>
    {
         IEnumerable<News> GetNewsByCondominium(int condominiumId);
    }
}