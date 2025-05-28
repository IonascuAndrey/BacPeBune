using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacPeBune.Models
{
    public class Lesson
    {
        [Key]
        public required int LessonID { get; set; }

        [Required]
        public required int Lector { get; set; }

        [Required]
        public required string SubjectID { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string PdfLink { get; set; }


    }
}