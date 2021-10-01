using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Residents
    {
        public Residents()
        {
            PaymentBills = new HashSet<PaymentBills>();
            PollOptionsByResidents = new HashSet<PollOptionsByResidents>();
            ResidentDepartments = new HashSet<ResidentDepartments>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<PaymentBills> PaymentBills { get; set; }
        public virtual ICollection<PollOptionsByResidents> PollOptionsByResidents { get; set; }
        public virtual ICollection<ResidentDepartments> ResidentDepartments { get; set; }
    }
}
