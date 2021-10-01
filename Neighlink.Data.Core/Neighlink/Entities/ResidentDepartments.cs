using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class ResidentDepartments
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Residents Resident { get; set; }
    }
}
