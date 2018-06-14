using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class AssignmentGridModel
    {
        public int AssignmentId { get; set; }
        public string InstructorName { get; set; }
        public string CourseTitle { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}