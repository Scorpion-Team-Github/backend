using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Payments
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PhotoUrl { get; set; }
        public int BillId { get; set; }
        public int UserId { get; set; }
        public bool HasPaid { get; set; }

        public virtual Bills Bill { get; set; }
        public virtual Users User { get; set; }
    }
}
