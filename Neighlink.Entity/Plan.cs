
using Neighlink.Entity.Entity;
using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class Plan:BaseEntity
    {
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public PlanType Type { get; set; }
        public virtual ICollection<Condominium> Condominiums { get; set; }
    
    }
}