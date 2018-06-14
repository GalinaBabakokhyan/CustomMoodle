using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Model;

namespace Domain.Entities
{
    public class SubmitedAssignment
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SumbitionDate { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; }
        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }
        public Grade? Grade { get; set; }

    }
}