using Microsoft.EntityFrameworkCore;
using Neighlink.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neighlink.Repository.implementation
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private ApplicationDbContext _context;

        public void Init(ApplicationDbContext context)
        {
            if (_context == null)
            {
                _context = context;
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find( id );
            _context.Set<T>().Remove( entity );
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find( id );
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add( entity );
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry( entity ).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
