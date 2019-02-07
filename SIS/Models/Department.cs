using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Courses>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
