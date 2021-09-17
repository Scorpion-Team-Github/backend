using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class PaymentCategory:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual int CondominiumId { get; set; }

     }
}