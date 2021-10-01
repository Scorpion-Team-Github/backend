using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Users
    {
        public Users()
        {
            Administrators = new HashSet<Administrators>();
            Residents = new HashSet<Residents>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Administrators> Administrators { get; set; }
        public virtual ICollection<Residents> Residents { get; set; }
    }
}
