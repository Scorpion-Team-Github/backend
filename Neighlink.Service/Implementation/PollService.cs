using System.Collections.Generic;
using Neighlink.Entity.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class PollService : IPollService
    {
        private IPollRepository _pollRepository;
        public PollService(ApplicationDbContext context)
        {
            _pollRepository = new PollRepository( context );
        }
        public void Add(Poll entity)
        {
            _pollRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _pollRepository.Delete( id );
        }

        public Poll Get(int id)
        {
            return _pollRepository.GetById( id );
        }

        public IEnumerable<Poll> GetAll()
        {
            return _pollRepository.GetAll();
        }

        public void Update(Poll entity)
        {
            _pollRepository.Update( entity );
        }
    }
}