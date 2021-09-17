using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Neighlink.Entity;
using Neighlink.Repository;
using Neighlink.Repository.Context;
using Neighlink.Repository.implementation;

namespace Neighlink.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(ApplicationDbContext context, IOptions<PrivateSettings> settings)
        {
            _userRepository = new UserRepository( context, settings );
        }

        public void Add(User entity)
        {
            _userRepository.Add( entity );
        }

        public void Delete(int id)
        {
            _userRepository.Delete( id );
        }

        public User Get(int id)
        {
            return _userRepository.GetById( id );
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Update(User entity)
        {
            _userRepository.Update( entity );
        }

        public User Authenticate(string email, string password)
        {
            return _userRepository.Authenticate( email, password );
        }

        public bool RegisterAdmin(User user, int condominiumId)
        {
            return _userRepository.RegisterAdmin( user, condominiumId );
        }

        public bool RegisterOwner(User user, int buildingId)
        {
            return _userRepository.RegisterOwner( user, buildingId );
        }

        public IEnumerable<User> GetUsersByCondominium(int condominiumId)
        {
            return _userRepository.GetUsersByCondominium( condominiumId );
        }

        public bool UserBelongsToCondominium(User user, int condominiumId)
        {
            return _userRepository.UserBelongsToCondominium( user, condominiumId );
        }
    }
}
