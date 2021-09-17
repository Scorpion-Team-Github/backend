using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface IUserService : ICrudService<User>
    {
        User Authenticate(string email, string password);
        bool RegisterOwner(User user, int buildingId);
        bool RegisterAdmin(User user, int condominiumId);
        bool UserBelongsToCondominium(User user, int condominiumId);
        IEnumerable<User> GetUsersByCondominium(int condominiumId);
    }
}
