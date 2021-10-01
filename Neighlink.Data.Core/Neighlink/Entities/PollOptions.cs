using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class PollOptions
    {
        public PollOptions()
        {
            PollOptionsByResidents = new HashSet<PollOptionsByResidents>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CondominiumPollId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual CondominiumPolls CondominiumPoll { get; set; }
        public virtual ICollection<PollOptionsByResidents> PollOptionsByResidents { get; set; }
    }
}
