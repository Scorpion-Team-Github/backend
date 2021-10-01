using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class DepartmentBills
    {
        public DepartmentBills()
        {
            PaymentBills = new HashSet<PaymentBills>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Amount { get; set; }
        public int DepartmentId { get; set; }
        public int PaymentCategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Departments Department { get; set; }
        public virtual PaymentCategories PaymentCategory { get; set; }
        public virtual ICollection<PaymentBills> PaymentBills { get; set; }
    }
}
