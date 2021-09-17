using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface ICrudRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}