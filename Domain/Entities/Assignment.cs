using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Assignment
    {
        public Assignment()
        {
            SubmitedAssignments = new HashSet<SubmitedAssignment>();
        }
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        [ForeignKey("InstructorId")]
        public ApplicationUser Instructor { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public ICollection<SubmitedAssignment> SubmitedAssignments { get; set; }
    }
}