using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface ICrudService<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}