using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class Registration
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int TermId { get; set; }

        public Courses Course { get; set; }
        public Student Student { get; set; }
        public StudyTerm Term { get; set; }
    }
}
