using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Buildings
    {
        public Buildings()
        {
            Bills = new HashSet<Bills>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public int CondominiumId { get; set; }

        public virtual Condominiums Condominium { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
