using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Users
    {
        public Users()
        {
            Payments = new HashSet<Payments>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] Salt { get; set; }
        public byte[] SaltedAndHashedPassword { get; set; }
        public string SecurityToken { get; set; }
        public int Role { get; set; }
        public int HouseNumber { get; set; }
        public int? BuildingId { get; set; }
        public int? CondominiumId { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Condominiums Condominium { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
