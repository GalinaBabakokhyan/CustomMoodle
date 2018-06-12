using System.Collections.Generic;
using System.ComponentModel;
using Domain.Entities;

namespace Domain.Model
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        [DisplayName("First Name")]
        public string  FirstName { get; set; }
        [DisplayName("Second Name")]
        public string  SecondName { get; set; }
        [DisplayName("Last Name")]
        public string  LastName { get; set; }        
        [DisplayName("Card Name")]
        public string CardNumber { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}