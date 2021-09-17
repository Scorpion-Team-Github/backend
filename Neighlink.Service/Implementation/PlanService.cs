using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class PlanService : IPlanService
    {
        private IPlanRepository _planRepository;
        public PlanService(ApplicationDbContext context)
        {
            _planRepository = new PlanRepository( context );
        }
        public void Add(Plan entity)
        {
            _planRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _planRepository.Delete( id );
        }

        public Plan Get(int id)
        {
            return _planRepository.GetById( id );
        }

        public IEnumerable<Plan> GetAll()
        {
            return _planRepository.GetAll();
        }

        public void Update(Plan entity)
        {
            _planRepository.Update( entity );
        }
    }
}