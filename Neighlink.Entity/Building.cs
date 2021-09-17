using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class Building:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual int CondominiumId { get; set; }
    }
}