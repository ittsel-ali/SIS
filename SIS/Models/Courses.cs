using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Registration = new HashSet<Registration>();
            TeachingAssignment = new HashSet<TeachingAssignment>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Registration> Registration { get; set; }
        public ICollection<TeachingAssignment> TeachingAssignment { get; set; }
    }
}
