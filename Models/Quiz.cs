using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacPeBune.Models
{
    public class Quiz
    {
        [Key]
        public required int QuizID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Reward { get; set; }

        [Required]
        public required int LessonID { get; set; }

        [ForeignKey(nameof(LessonID))]
        public required Lesson lesson { get; set; }
    }
}