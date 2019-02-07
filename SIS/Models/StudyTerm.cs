using System;
using System.Collections.Generic;

namespace SIS.Models
{
    public partial class StudyTerm
    {
        public StudyTerm()
        {
            Registration = new HashSet<Registration>();
            TeachingAssignment = new HashSet<TeachingAssignment>();
        }

        public int TermId { get; set; }
        public string TermName { get; set; }
        public DateTime? TermStartDate { get; set; }
        public DateTime? TermEndDate { get; set; }
        public int? TermYear { get; set; }
        public string TermSeason { get; set; }

        public ICollection<Registration> Registration { get; set; }
        public ICollection<TeachingAssignment> TeachingAssignment { get; set; }
    }
}
