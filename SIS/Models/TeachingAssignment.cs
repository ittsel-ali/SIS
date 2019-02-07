using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class TeachingAssignment
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int TermId { get; set; }

        public Courses Course { get; set; }
        public Instructor Instructor { get; set; }
        public StudyTerm Term { get; set; }
    }
}
