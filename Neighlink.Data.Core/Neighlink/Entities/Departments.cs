using System;
using System.Collections.Generic;

#nullable disable

namespace Neighlink.Data.Core.Neighlink.Entities
{
    public partial class Departments
    {
        public Departments()
        {
            DepartmentBills = new HashSet<DepartmentBills>();
            DepartmentDoors = new HashSet<DepartmentDoors>();
            ResidentDepartments = new HashSet<ResidentDepartments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public string SecretCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Status { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual ICollection<DepartmentBills> DepartmentBills { get; set; }
        public virtual ICollection<DepartmentDoors> DepartmentDoors { get; set; }
        public virtual ICollection<ResidentDepartments> ResidentDepartments { get; set; }
    }
}
