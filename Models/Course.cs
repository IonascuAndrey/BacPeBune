using System.ComponentModel.DataAnnotations;

namespace BacPeBune.Models
{
    public class Course
    {
        [Key]
        public required int CourseID { get; set; }

        [Required]
        public required string SubjectID { get; set; }

        [Required]
        public required int Name { get; set; }
    }
}