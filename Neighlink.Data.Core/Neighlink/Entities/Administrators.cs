using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Administrators
    {
        public Administrators()
        {
            CondominiumPolls = new HashSet<CondominiumPolls>();
            Condominiums = new HashSet<Condominiums>();
            PlanMembers = new HashSet<PlanMembers>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<CondominiumPolls> CondominiumPolls { get; set; }
        public virtual ICollection<Condominiums> Condominiums { get; set; }
        public virtual ICollection<PlanMembers> PlanMembers { get; set; }
    }
}
