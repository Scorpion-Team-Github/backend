using System;
using System.Collections.Generic;
using System.Text;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class NewService : INewService
    {
        private INewRepository _newRepository;
        public NewService(ApplicationDbContext context)
        {
            _newRepository = new NewRepository( context );
        }
        public void Add(News entity)
        {
            _newRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _newRepository.Delete( id );
        }

        public News Get(int id)
        {
            return _newRepository.GetById( id );
        }

        public IEnumerable<News> GetAll()
        {
            return _newRepository.GetAll();
        }

        public void Update(News entity)
        {
            _newRepository.Update( entity );
        }
        public IEnumerable<News> GetNewsByCondominium(int condominiumId)
        {
            return _newRepository.GetNewsByCondominium( condominiumId );
        }
    }
}