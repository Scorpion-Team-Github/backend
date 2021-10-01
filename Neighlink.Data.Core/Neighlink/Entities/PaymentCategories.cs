using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class PaymentCategories
    {
        public PaymentCategories()
        {
            Bills = new HashSet<Bills>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Names { get; set; }
        public string Descriptions { get; set; }
        public int CondominiumId { get; set; }

        public virtual Condominiums Condominium { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
    }
}
