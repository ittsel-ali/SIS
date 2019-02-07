using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class Student
    {
        public Student()
        {
            Registration = new HashSet<Registration>();
        }

        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEnrollment { get; set; }
        public string StudentPhone { get; set; }

        public ICollection<Registration> Registration { get; set; }
    }
}
