using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class PlanMembers
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DatePayed { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsPayed { get; set; }
        public int AdministratorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Administrators Administrator { get; set; }
    }
}
