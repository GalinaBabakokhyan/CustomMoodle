using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Domain.Model
{
    public class AssignmentSubmitModel
    {
        public int AssignmentId { get; set; }
        public string Description { get; set; }
        [Required]
        public IFormFile  AssignmentFile { get; set; }

        public string FilePath { get; set; }
        public int StudentId { get; set; }
    }
}