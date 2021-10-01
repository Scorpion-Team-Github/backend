using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Bills
    {
        public Bills()
        {
            Payments = new HashSet<Payments>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? PaymentCategoryId { get; set; }
        public int? BuildingId { get; set; }
        public int? CondominiumId { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Condominiums Condominium { get; set; }
        public virtual PaymentCategories PaymentCategory { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
