using System;
using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class Bill :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(2019, 08, 25);
        public DateTime EndDate { get; set; } = new DateTime(2019, 08, 25);
        public virtual int? PaymentCategoryId { get; set; }
        public virtual int? BuildingId { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}