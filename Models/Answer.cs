using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacPeBune.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public required string Text { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public required int QuestionID { get; set; }

        [ForeignKey(nameof(QuestionID))]
        public required Question question { get; set; }
    }
}