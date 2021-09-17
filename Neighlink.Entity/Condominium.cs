
using Neighlink.Entity.Entity;
using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class Condominium : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SecretCode { get; set; }
        public virtual ICollection<User> Administrators { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<PaymentCategory> PaymentCategories { get; set; }
        public virtual ICollection<News> New { get; set; }       
        public virtual ICollection<Bill> Bills { get; set; }         
    }
}
