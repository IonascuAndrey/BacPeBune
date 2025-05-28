using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacPeBune.Models
{
    public class Question
    {
        [Key]
        public required int QuestionID { get; set; }

        [Required]
        public required string Text { get; set; }

        [Required]
        public required int QuizID { get; set; }

        [ForeignKey(nameof(QuizID))]
        public required Quiz Quiz { get; set; }
    }
}