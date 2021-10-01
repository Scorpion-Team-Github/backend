using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Condominiums
    {
        public Condominiums()
        {
            Bills = new HashSet<Bills>();
            Buildings = new HashSet<Buildings>();
            News = new HashSet<News>();
            PaymentCategories = new HashSet<PaymentCategories>();
            Polls = new HashSet<Polls>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SecretCode { get; set; }
        public int? PlanId { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<PaymentCategories> PaymentCategories { get; set; }
        public virtual ICollection<Polls> Polls { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
