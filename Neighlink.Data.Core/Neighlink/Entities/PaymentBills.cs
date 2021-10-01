using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class PaymentBills
    {
        public int Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double Amount { get; set; }
        public bool? IsValid { get; set; }
        public int ResidentId { get; set; }
        public int DepartmentBillId { get; set; }
        public string PaymentImage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual DepartmentBills DepartmentBill { get; set; }
        public virtual Residents Resident { get; set; }
    }
}
