using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Plans
    {
        public Plans()
        {
            Condominiums = new HashSet<Condominiums>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Condominiums> Condominiums { get; set; }
    }
}
