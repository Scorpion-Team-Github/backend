using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class OptionService : IOptionService
    {
        private IOptionRepository _optionRepository;
        public OptionService(ApplicationDbContext context)
        {
            _optionRepository = new OptionRepository( context );
        }
        public void Add(Option entity)
        {
            _optionRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _optionRepository.Delete( id );
        }

        public Option Get(int id)
        {
            return _optionRepository.GetById( id );
        }

        public IEnumerable<Option> GetAll()
        {
            return _optionRepository.GetAll();
        }

        public void Update(Option entity)
        {
            _optionRepository.Update( entity );
        }
    }
}