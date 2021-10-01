using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class PollOptionsByResidents
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int PollOptionId { get; set; }
        public int ResidentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual PollOptions PollOption { get; set; }
        public virtual Residents Resident { get; set; }
    }
}
