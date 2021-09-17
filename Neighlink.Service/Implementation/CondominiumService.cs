using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class CondominiumService : ICondominiumService
    {
        private ICondominiumRepository _condominiumRepository;
        public CondominiumService(ApplicationDbContext context)
        {
            _condominiumRepository = new CondominiumRepository( context );
        }
        public void Add(Condominium entity)
        {
            _condominiumRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _condominiumRepository.Delete( id );
        }

        public Condominium Get(int id)
        {
            return _condominiumRepository.GetById( id );
        }

        public IEnumerable<Condominium> GetAll()
        {
            return _condominiumRepository.GetAll();
        }

        public void Update(Condominium entity)
        {
            _condominiumRepository.Update( entity );
        }
    }
}