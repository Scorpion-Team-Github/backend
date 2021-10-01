using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Condominiums
    {
        public Condominiums()
        {
            Buildings = new HashSet<Buildings>();
            CondominiumNews = new HashSet<CondominiumNews>();
            CondominiumPolls = new HashSet<CondominiumPolls>();
            CondominiumRules = new HashSet<CondominiumRules>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int AdministratorId { get; set; }
        public int NumberOfHomes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<CondominiumNews> CondominiumNews { get; set; }
        public virtual ICollection<CondominiumPolls> CondominiumPolls { get; set; }
        public virtual ICollection<CondominiumRules> CondominiumRules { get; set; }
    }
}
