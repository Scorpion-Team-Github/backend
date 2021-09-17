using System.Collections.Generic;
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class User :BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] Salt { get; set; }
        public byte[] SaltedAndHashedPassword { get; set; }
        public string SecurityToken { get; set; }
        public Role Role {get;set;}
        public int HouseNumber {get;set;}
        public int? BuildingId {get;set;}
        public int? CondominiumId {get;set;}
        public virtual ICollection<Payment> Payments { get; set; }
    }
}