﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Polls
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StarDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int? CondominiumId { get; set; }

        public virtual Condominiums Condominium { get; set; }
    }
}
