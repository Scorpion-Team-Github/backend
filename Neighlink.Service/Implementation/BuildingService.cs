using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.implementation
{
    public class BuildingService : IBuildingService
    {
        private IBuildingRepository _buildingRepository;
        public BuildingService(ApplicationDbContext context)
        {
            _buildingRepository = new BuildingRepository( context );
        }
        public void Add(Building entity)
        {
            _buildingRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _buildingRepository.Delete( id );
        }

        public Building Get(int id)
        {
            return _buildingRepository.GetById( id );
        }

        public IEnumerable<Building> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public void Update(Building entity)
        {
            _buildingRepository.Update( entity );
        }

        public IEnumerable<Building> GetBuildingsByCondominium(int condominiumId)
        {
            return _buildingRepository.GetBuildingsByCondominium( condominiumId );
        }
    }
}