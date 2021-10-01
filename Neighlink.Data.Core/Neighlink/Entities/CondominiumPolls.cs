using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class CondominiumPolls
    {
        public CondominiumPolls()
        {
            PollOptions = new HashSet<PollOptions>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CondominiumId { get; set; }
        public int AdministratorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual Condominiums Condominium { get; set; }
        public virtual ICollection<PollOptions> PollOptions { get; set; }
    }
}
