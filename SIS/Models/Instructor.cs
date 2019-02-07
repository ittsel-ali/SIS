using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            TeachingAssignment = new HashSet<TeachingAssignment>();
        }

        public int InstructorId { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorHireDepartment { get; set; }

        public ICollection<TeachingAssignment> TeachingAssignment { get; set; }
    }
}
