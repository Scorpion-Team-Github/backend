using Neighlink.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Contracts
{
    public class RegisterUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int HouseNumber { get; set; }
        public int CondominiumId { get; set; }
        public int BuildingId { get; set; }
    }
}
